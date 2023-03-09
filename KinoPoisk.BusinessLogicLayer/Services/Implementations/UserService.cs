using AutoMapper;
using AutoMapper.QueryableExtensions;
using Google.Apis.Auth;
using KinoPoisk.BusinessLogicLayer.Services.Base;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.DomainLayer.Settings;
using KinoPoisk.PresentationLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Web;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class UserService : SearchableEntityService<UserService, ApplicationUser, Guid, UserDTO, PageableUserRequestDto>, IUserService {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IAccessService _accessService;
        private readonly LinkGenerator _generator;
        private readonly IOptions<GoogleAuthSettings> _googleSettings;

        public UserService(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            IEmailService emailService,
            IAccessService accessService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptions<GoogleAuthSettings> googleSettings,
            LinkGenerator generator) : base(unitOfWork, mapper) {
            _userManager = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _accessService = accessService;
            _generator = generator;
            _googleSettings = googleSettings;
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

        public override async Task<ServiceResult> CreateAsync(UserDTO dto) {
            var validationResult = Validate(dto);

            if (validationResult.Failure) {
                return validationResult;
            }

            var user = _mapper.Map<ApplicationUser>(dto);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken.Token;
            user.RefreshTokenExpiryDate = refreshToken.ExpirationDate; 

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, Constants.NameRoleUser);
                //await SendConfirmationEmailAsync(user, UserResource.TextConfirmEmail);

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

        public async Task<ServiceResult> AuthorizationWithGoogle(string token) {
            try {
                var googleUser = await GoogleJsonWebSignature.ValidateAsync(token, new GoogleJsonWebSignature.ValidationSettings() {
                    Audience = new[] { _googleSettings.Value.ClientId }
                });

                if (googleUser is null) {
                    return ServiceResult.Fail(UserResource.NotFound);
                }

                var user = await _userManager.FindByEmailAsync(googleUser.Email);
                var refreshToken = _tokenService.GenerateRefreshToken();
                await _emailService.SendEmailResultAuthentificationWithGoogle(user.Email);

                if (user is not null) {
                    return ServiceResult.Ok(
                    new AuthResponseDTO<GetUserDTO> {
                        Data = _mapper.Map<GetUserDTO>(user),
                        AccessToken = await _tokenService.GenerateAccessToken(user),
                        RefreshToken = refreshToken.Token
                    });
                }

                user = new ApplicationUser() {
                    UserName = googleUser.Email,
                    FirstName = googleUser.GivenName,
                    LastName = googleUser.FamilyName,
                    Email = googleUser.Email,
                    DateOfBirth = default,
                    RefreshToken = refreshToken.Token,
                    RefreshTokenExpiryDate = refreshToken.ExpirationDate,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded) {
                    await _userManager.AddToRoleAsync(user, Constants.NameRoleUser);

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
            catch {
                return ServiceResult.Fail(UserResource.FailAuthentificationWithGoogle);
            }
        }

        public override async Task<ServiceResult> UpdateAsync(UserDTO userDTO) {
            var validationResult = Validate(userDTO);

            if (validationResult.Failure) {
                return validationResult; 
            }

            if (!_accessService.IsHasAccess(userDTO.Id)) {
                return ServiceResult.Fail(UserResource.AccessDenied);
            }

            var user = await _userManager.FindByIdAsync(userDTO.Id.ToString());

            if (user is null) {
                return ServiceResult.Fail(UserResource.NotFound);
            }

            var updateDto = _mapper.Map<UpdateUserDTO>(userDTO);
            user = _mapper.Map(updateDto, user); 
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) {
                return ServiceResult.Ok();
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList()); 
        }

        public override async Task<ServiceResult> DeleteAsync(Guid userId) {
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

        public override async Task<ServiceResult> GetAsync<TGetUserDto>(){
            return ServiceResult.Ok( await _userManager.Users
                .ProjectTo<TGetUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync()); 
        }

        public override async Task<ServiceResult> GetByIdAsync<TGetUserDto>(Guid id) {
            var user = await _userManager.FindByIdAsync(id.ToString());

            return user is null ? ServiceResult.Fail(UserResource.NotFound)
                : ServiceResult.Ok(_mapper.Map<TGetUserDto>(user));
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

        protected override ServiceResult Validate(UserDTO user) {
            var errors = new List<string>();

            if (user is null) {
                errors.Add(UserResource.NullArgument);
                return BuildValidateResult(errors);
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
            else if(user.Patronymic is null) {
                user.Patronymic = string.Empty;
            }

            if (user.Patronymic is not null && user.Patronymic.Length > Constants.MaxLenOfName) {
                errors.Add(UserResource.PatronymicExceedsMaxLen);
            }

            if (user.DateOfBirth < DateTime.UtcNow.AddYears(Constants.CountValidateYear) || user.DateOfBirth > DateTime.UtcNow) {
                errors.Add(UserResource.IncorrectDateOfBirth);
            }

            if (user.CountryId is not null && _unitOfWork.GetRepository<Country>().FindById(user.CountryId) is null) {
                errors.Add(UserResource.NotFoundUserCountry);
            }

            if (user.IsNew) {
                var emailValidate = ValidateEmail(user.Email);
                var passwordValidate = ValidatePassword(user.Password);

                if (!emailValidate.isValid) {
                    errors.Add(emailValidate.message);
                }

                if (!passwordValidate.isValid) {
                    errors.Add(passwordValidate.message);
                }
            }
            
            return BuildValidateResult(errors);
        }
        protected override List<Expression<Func<ApplicationUser, bool>>> GetAdvancedConditions(PageableUserRequestDto filters) {
            var conditions = new List<Expression<Func<ApplicationUser, bool>>>();

            if(!string.IsNullOrEmpty(filters.Country)) {
                conditions.Add(x => x.Country != null && x.Country.Name == filters.Country);
            }

            if(filters.AgeFrom is not null) {
                conditions.Add(x => DateTime.UtcNow.Year - x.DateOfBirth.Year > filters.AgeFrom);
            }

            if (filters.AgeTo is not null) {
                conditions.Add(x => DateTime.UtcNow.Year - x.DateOfBirth.Year < filters.AgeTo);
            }

            return conditions;
        }

        protected override IQueryable<ApplicationUser> GetEntityByIdIncludes(IQueryable<ApplicationUser> query) {
            return query;
        }
    }
}
