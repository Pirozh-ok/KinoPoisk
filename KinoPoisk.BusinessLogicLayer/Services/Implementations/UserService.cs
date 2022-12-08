using AutoMapper;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.PresentationLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using System.Web;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class UserService : IUserService {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _accessor;
        private readonly LinkGenerator _generator;

        public UserService(UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IEmailService emailService,
            IHttpContextAccessor accessor,
            LinkGenerator generator) {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _accessor = accessor;
            _generator = generator;
        }

        public async Task<Result> LoginAsync(LoginDTO dto) {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null) {
                return new ErrorResult(new List<string>() { UserResource.InvalidEmailOrPassword });
            }

            if (await _userManager.CheckPasswordAsync(user, dto.Password)) {
                var refreshToken = _tokenService.GenerateRefreshToken();
                user.RefreshToken = refreshToken.Token;
                user.RefreshTokenExpiryDate = refreshToken.ExpirationDate;
                await _userManager.UpdateAsync(user);

                return new SuccessResult<AuthResponseDTO<GetUserDTO>>(
                    new AuthResponseDTO<GetUserDTO> {
                        Data = _mapper.Map<GetUserDTO>(user),
                        AccessToken = await _tokenService.GenerateAccessToken(user),
                        RefreshToken = refreshToken.Token
                    });
            }

            return new ErrorResult(new List<string>() { UserResource.InvalidEmailOrPassword });
        }

        public async Task<Result> RegisterAsync(CreateUserDTO dto) {
            var validatedErrors = ValidateData(dto);

            if (validatedErrors.Count() > 0) {
                return new ErrorResult(validatedErrors);
            }

            var user = _mapper.Map<ApplicationUser>(dto);

            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken.Token;
            user.RefreshTokenExpiryDate = refreshToken.ExpirationDate; 

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, Constants.NameRoleUser);
                await SendConfirmationEmail(user);

                return new SuccessResult<AuthResponseDTO<GetUserDTO>>(
                    new AuthResponseDTO<GetUserDTO> {
                        Data = _mapper.Map<GetUserDTO>(user),
                        AccessToken = await _tokenService.GenerateAccessToken(user),
                        RefreshToken = refreshToken.Token
                    });
            }

            var errors = new List<string>();

            foreach (var error in result.Errors) {
                errors.Add(error.Description.ToString());
            }

            return new ErrorResult(errors);
        }

        public async Task<Result> ConfirmEmailAsync(string? userEmail) {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user.EmailConfirmed) {
                return new SuccessResult<string>(UserResource.EmailAlreadyConfirmed); 
            }

            await SendConfirmationEmail(user);
            return new SuccessResult<string>(UserResource.ChechkEmail);
        }

        public async Task<Result> VerificationConfirmationToken(string token, string email) {
            var user = await _userManager.FindByEmailAsync(email);

            if(user is null) {
                return new ErrorResult(new List<string> { UserResource.NotFound });
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded) {
                return new SuccessResult<string>(UserResource.EmailConfirmed);
            }

            var errors = new List<string>();

            foreach (var error in result.Errors) {
                errors.Add(error.Description.ToString());
            }

            return new ErrorResult(errors);
        }

        private async Task SendConfirmationEmail(ApplicationUser user) {
            if(user is null) {
                return; 
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            token = HttpUtility.UrlEncode(token);

            //var callbackUrl = _generator.GetUriByAction(_accessor.HttpContext,
            //    action: "Confirm-Email",
            //    controller: "Account",
            //    values: new { token, email = user.Email });
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            var callbackUrl = $"{scheme}://{host}/api/account/confirm-email?token={token}&email={user.Email}"; 

            await _emailService.SendEmailAsync(user.Email, "Confirm your account",
                $"Hi {user.UserName}!<br>You have been sent this email because you created an account on kinopoisk.<br>Please confirm your account by clicking this link: <a href=\"{callbackUrl}\">link</a>");
        }

        private IEnumerable<string> ValidateData(CreateUserDTO user) {
            var errors = new List<string>();

            if (user is null) {
                errors.Add(UserResource.NullArgument);
                return errors; 
            }

            if (string.IsNullOrEmpty(user.UserName) || user.UserName.Length < 2) {
                errors.Add(UserResource.UserNameLessMinLen);
            }

            if (user.UserName.Length > 50) {
                errors.Add(UserResource.UserNameExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(user.FirstName) || user.FirstName.Length < 2) {
                errors.Add(UserResource.FirstNameLessMinLen);
            }

            if (user.FirstName.Length > 50) {
                errors.Add(UserResource.FirstNameExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(user.LastName) || user.LastName.Length < 2) {
                errors.Add(UserResource.LastNameLessMinLen);
            }

            if (user.LastName.Length > 50) {
                errors.Add(UserResource.LastNameExceedsMaxLen);
            }

            if (user.Patronymic is not null && user.Patronymic.Length < 2) {
                errors.Add(UserResource.PatronymicLessMinLen);
            }

            if (user.Patronymic is not null && user.Patronymic.Length > 50) {
                errors.Add(UserResource.PatronymicExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(user.Email) || user.Email.Length < 2) {
                errors.Add(UserResource.EmailLessMinLen);
            }

            if (user.Email.Length > 50) {
                errors.Add(UserResource.EmailExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 6) {
                errors.Add(UserResource.PasswordLessMinLen);
            }

            if (string.IsNullOrEmpty(user.Password) || user.Password.Length > 30) {
                errors.Add(UserResource.PasswordExceedsMaxLen);
            }

            if (user.DateOfBirth < DateTime.UtcNow.AddYears(-100) || user.DateOfBirth > DateTime.UtcNow) {
                errors.Add(UserResource.IncorrectDateOfBirth);
            }

            if (_unitOfWork.GetRepository<Country>().GetById(user.CountryId) is null) {
                errors.Add(UserResource.NotFoundUserCountry);
            }

            return errors;
        }
    }
}
