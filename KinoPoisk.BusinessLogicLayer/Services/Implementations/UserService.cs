using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.PresentationLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class UserService : IUserService {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IAccessService _accessService;
        private readonly LinkGenerator _generator;

        public UserService(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IEmailService emailService,
            IAccessService accessService,
            LinkGenerator generator) {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _accessService = accessService;
            _generator = generator;
        }

        public async Task<ServiceResult> LoginAsync(LoginDTO dto) {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null) {
                return ServiceResult.Fail(UserResource.InvalidEmailOrPassword);
            }

            if (await _userManager.CheckPasswordAsync(user, dto.Password)) {
                var refreshToken = _tokenService.GenerateRefreshToken();
                user.RefreshToken = refreshToken.Token;
                user.RefreshTokenExpiryDate = refreshToken.ExpirationDate;
                await _userManager.UpdateAsync(user);

                return ServiceResult.Ok(
                    new AuthResponseDTO<GetUserDTO> 
                    {
                        Data = _mapper.Map<GetUserDTO>(user), 
                        AccessToken = await _tokenService.GenerateAccessToken(user), 
                        RefreshToken = refreshToken.Token 
                    });
            }

            return ServiceResult.Fail(UserResource.InvalidEmailOrPassword);
        }

        public async Task<ServiceResult> RegisterAsync(UserDTO dto) {
            var validatedErrors = ValidateData(dto);

            if (validatedErrors.Count() > 0) {
                return ServiceResult.Fail(validatedErrors);
            }

            var user = _mapper.Map<ApplicationUser>(dto);
            user.Id = Guid.Empty; 
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken.Token;
            user.RefreshTokenExpiryDate = refreshToken.ExpirationDate; 

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, Constants.NameRoleUser);
                await SendConfirmationEmailAsync(user, UserResource.TextConfirmEmail);

                return ServiceResult.Ok(
                    new AuthResponseDTO<GetUserDTO> {
                        Data = _mapper.Map<GetUserDTO>(user),
                        AccessToken = await _tokenService.GenerateAccessToken(user),
                        RefreshToken = refreshToken.Token
                    });
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        }

        public async Task<ServiceResult> UpdateUserDataAsync(UpdateUserDTO userDTO) {
            var errors = ValidateData(userDTO);

            if (errors.Count > 0) {
                return ServiceResult.Fail(errors); 
            }

            if (!_accessService.IsHasAccess(userDTO.Id)) {
                return ServiceResult.Fail(UserResource.AccessDenied);
            }

            var user = await _userManager.FindByIdAsync(userDTO.Id.ToString());

            if (user is null) {
                return ServiceResult.Fail(UserResource.NotFound);
            }

            user = _mapper.Map(userDTO, user); 
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) {
                return ServiceResult.Ok();
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList()); 
        }

        public async Task<ServiceResult> DeleteUserAsync(Guid userId) {
            if (!_accessService.IsHasAccess(userId)) {
                return ServiceResult.Fail(UserResource.AccessDenied);
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null) {
                return ServiceResult.Fail(UserResource.NotFound);
            }

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded ? ServiceResult.Ok() : 
                ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        }

        public async Task<ServiceResult> ConfirmEmailAsync() {
            var userId = _accessService.GetUserIdFromRequest().ToString(); 
            var user = await _userManager.FindByIdAsync(userId);
            if(user is null) {
                return ServiceResult.Fail(UserResource.NotFound); 
            }

            if (user.EmailConfirmed) {
                return ServiceResult.Ok(UserResource.EmailAlreadyConfirmed); 
            }

            await SendConfirmationEmailAsync(user, UserResource.TextConfirmEmail);
            return ServiceResult.Ok(UserResource.ChechkEmail);
        }

        public async Task<ServiceResult> VerificationConfirmationTokenAsync(string token, string email) {
            var user = await _userManager.FindByEmailAsync(email);

            if(user is null) {
                return ServiceResult.Fail(UserResource.NotFound);
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded) {
                return ServiceResult.Ok(UserResource.EmailConfirmed);
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        }

        public async Task<ServiceResult> ChangePasswordAsync(ChangePasswordDTO changePasswordData) {
            var userId = _accessService.GetUserIdFromRequest().ToString(); 
            var user = await _userManager.FindByIdAsync(userId);

            if(user is null) {
                return ServiceResult.Fail(UserResource.NotFound); 
            }

            if(!string.Equals(changePasswordData.NewPassword, changePasswordData.ConfirmNewPassword)) {
                return ServiceResult.Fail(UserResource.PasswordsNotMatch);
            }

            var result = await _userManager.ChangePasswordAsync(user, changePasswordData.OldPassword, changePasswordData.NewPassword);

            if (result.Succeeded) {
                await _emailService.SendEmailAsync(user.Email, UserResource.SubjectPasswordChanged, UserResource.EmailPasswordChanged); 
                return ServiceResult.Ok(UserResource.PasswordChanged);
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList()); 
        }

        public async Task<ServiceResult> ChangeEmailAsync(string newEmail) {
            var userId = _accessService.GetUserIdFromRequest().ToString(); 
            var user = await _userManager.FindByIdAsync(userId);

            if(user is null) {
                return ServiceResult.Fail(UserResource.NotFound);
            }

            var validateEmail = ValidateEmail(newEmail);

            if (!validateEmail.isValid) {
                return ServiceResult.Fail(validateEmail.message); 
            }
         
            user.Email = newEmail;
            user.EmailConfirmed = false; 
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) {
                await SendConfirmationEmailAsync(user, UserResource.ConfirmUpdatedEmail);
                return ServiceResult.Ok(UserResource.ChechkEmail);
            }
            
            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        } 

        public async Task<ServiceResult> SendResetPasswordEmailAsync(string email) {
            var validateEmail = ValidateEmail(email);

            if (!validateEmail.isValid) {
                return ServiceResult.Fail(validateEmail.message); 
            }

            var user = await _userManager.FindByEmailAsync(email); 
            
            if(user is null) {
                return ServiceResult.Fail(UserResource.NotFound);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = $"https://frontend/reset-password?token={token}";
            
            await _emailService.SendEmailAsync(user.Email, UserResource.SubjectConfirmEmail,
                string.Format(UserResource.TextResetEmail, user.UserName, $"<a href=\"{callbackUrl}\">link</a>"));

            return ServiceResult.Ok(); 
        }

        public async Task<ServiceResult> ResetPasswordAsync(ResetPasswordDTO resetPasswordData) {
            var resultValid = ValidateResetPasswordData(resetPasswordData);

            if (resultValid.Failure) {
                return resultValid; 
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordData.Email); 

            if(user is null) {
                return ServiceResult.Fail(UserResource.NotFound); 
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordData.Token, resetPasswordData.NewPassword);

            if (result.Succeeded) {
                return ServiceResult.Ok(); 
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList()); 
        }

        public async Task<ServiceResult> GetAllUsersAsync() {
            return ServiceResult.Ok(await _userManager.Users
                .ProjectTo<GetUserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync()); 
        }

        public async Task<ServiceResult> GetUserById(Guid id) {
            var user = await _userManager.FindByIdAsync(id.ToString());

            return user is null ? ServiceResult.Fail(UserResource.NotFound)
                : ServiceResult.Ok(_mapper.Map<GetUserDTO>(user));
        }

        private async Task SendConfirmationEmailAsync(ApplicationUser user, string message) {
            if(user is null) {
                return; 
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            token = HttpUtility.UrlEncode(token);

            //var callbackUrl = _generator.GetUriByAction(_accessor.HttpContext,
            //    action: "Confirm-Email",
            //    controller: "Account",
            //    values: new { token = token, email = user.Email });
            var scheme = _accessService.GetSchemeFromRequest();
            var host = _accessService.GetHostFromRequest();
            var callbackUrl = $"{scheme}://{host}/api/account/confirm-email?token={token}&email={user.Email}";

            await _emailService.SendEmailAsync(user.Email, UserResource.SubjectConfirmEmail, 
                string.Format(message, user.UserName, $"<a href=\"{callbackUrl}\">link</a>"));
        }

        private ServiceResult ValidateResetPasswordData(ResetPasswordDTO resetPasswordData) {
            if (resetPasswordData is null) {
                return ServiceResult.Fail(UserResource.NullArgument);
            }

            var validateNewPassword = ValidatePassword(resetPasswordData.NewPassword);

            if (!validateNewPassword.isValid) {
                return ServiceResult.Fail(validateNewPassword.message);
            }

            var validateConfirmPassword = ValidatePassword(resetPasswordData.ConfirmPassword);

            if (!validateConfirmPassword.isValid) {
                return ServiceResult.Fail(validateConfirmPassword.message);
            }

            if (!string.Equals(resetPasswordData.NewPassword, resetPasswordData.ConfirmPassword)) {
                return ServiceResult.Fail(UserResource.PasswordsNotMatch);
            }

            var validateEmail = ValidateEmail(resetPasswordData.Email);

            if (!validateEmail.isValid) {
                return ServiceResult.Fail(validateEmail.message);
            }

            return ServiceResult.Ok(); 
        }

        private (bool isValid, string message) ValidateEmail(string email) {
            if (string.IsNullOrEmpty(email) || email.Length < Constants.MinLenOfEmail) {
                return (false, UserResource.EmailLessMinLen);
            }

            if(email.Length > Constants.MaxLenOfEmail) {
                return (false, UserResource.EmailExceedsMaxLen);
            }

            return (true, string.Empty); 
        }

        private (bool isValid, string message) ValidatePassword(string password) {
            if (string.IsNullOrEmpty(password) || password.Length < Constants.MinLenOfPassword) {
                return (false, UserResource.PasswordLessMinLen);
            }

            if (password.Length > Constants.MaxLenOfPassword) {
                return (false, UserResource.PasswordExceedsMaxLen);
            }

            return (true, string.Empty);
        }

        private List<string> ValidateData(UserDTO user) {
            var errors = ValidateData(_mapper.Map<UpdateUserDTO>(user));

            var emailValidate = ValidateEmail(user.Email);
            var passwordValidate = ValidatePassword(user.Password);

            if (!emailValidate.isValid) {
                errors.Add(emailValidate.message);
            }

            if (!passwordValidate.isValid) {
                errors.Add(passwordValidate.message);
            }

            return errors;
        }

        private List<string> ValidateData(UpdateUserDTO user) {
            var errors = new List<string>();

            if (user is null) {
                errors.Add(UserResource.NullArgument);
                return errors;
            }

            if (string.IsNullOrEmpty(user.UserName) || user.UserName.Length < Constants.MinLenOfName) {
                errors.Add(UserResource.UserNameLessMinLen);
            }

            if (user.UserName.Length > Constants.MaxLenOfName) {
                errors.Add(UserResource.UserNameExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(user.FirstName) || user.FirstName.Length < Constants.MinLenOfName) {
                errors.Add(UserResource.FirstNameLessMinLen);
            }

            if (user.FirstName.Length > Constants.MaxLenOfName) {
                errors.Add(UserResource.FirstNameExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(user.LastName) || user.LastName.Length < Constants.MinLenOfName) {
                errors.Add(UserResource.LastNameLessMinLen);
            }

            if (user.LastName.Length > Constants.MaxLenOfName) {
                errors.Add(UserResource.LastNameExceedsMaxLen);
            }

            if (user.Patronymic is not null && user.Patronymic.Length < Constants.MinLenOfName) {
                errors.Add(UserResource.PatronymicLessMinLen);
            }

            if (user.Patronymic is not null && user.Patronymic.Length > Constants.MaxLenOfName) {
                errors.Add(UserResource.PatronymicExceedsMaxLen);
            }

            if (user.DateOfBirth < DateTime.UtcNow.AddYears(Constants.CountValidateYear) || user.DateOfBirth > DateTime.UtcNow) {
                errors.Add(UserResource.IncorrectDateOfBirth);
            }

            if (user.CountryId is not null && _unitOfWork.GetRepository<Country>().GetById(user.CountryId) is null) {
                errors.Add(UserResource.NotFoundUserCountry);
            }

            return errors;
        }
    }
}
