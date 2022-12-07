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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class UserService : IUserService {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _jwtService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _accessor;
        private readonly LinkGenerator _generator;

        public UserService(UserManager<ApplicationUser> userManager,
            IAuthService jwtService,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IEmailService emailService,
            IHttpContextAccessor accessor,
            LinkGenerator generator) {
            _userManager = userManager;
            _jwtService = jwtService;
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
                return new SuccessResult<AuthResponseDTO<GetUserDTO>>(await GetAuthResult(user));
            }

            return new ErrorResult(new List<string>() { UserResource.InvalidEmailOrPassword });
        }

        public async Task<Result> RegisterAsync(CreateUserDTO dto) {
            if (dto is null) {
                return new ErrorResult(new List<string> { UserResource.NullArgument });
            }

            var validatedErrors = dto.ValidateData();

            if (validatedErrors.Count() > 0) {
                return new ErrorResult(validatedErrors);
            }

            if (_unitOfWork.GetRepository<Country>().GetById(dto.CountryId) is null) {
                return new ErrorResult(new List<string> { UserResource.NotFoundUserCountry });
            }

            var user = _mapper.Map<ApplicationUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, Constants.NameRoleUser);
                await SendConfirmationEmail(user);
                return new SuccessResult<AuthResponseDTO<GetUserDTO>>(await GetAuthResult(user));
            }

            var errors = new List<string>();

            foreach (var error in result.Errors) {
                errors.Add(error.Description.ToString());
            }

            return new ErrorResult(errors);
        }

        public async Task ConfirmEmailAsync(string userEmail) {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user.EmailConfirmed) {
                return; 
            }

            await SendConfirmationEmail(user);
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

        private async Task<AuthResponseDTO<GetUserDTO>> GetAuthResult(ApplicationUser user) {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
             };

            foreach (var userRole in userRoles) {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = _jwtService.GenerateToken(authClaims);

            return new AuthResponseDTO<GetUserDTO> {
                Data = _mapper.Map<GetUserDTO>(user),
                AccessToken = token
            };
        }

        private async Task SendConfirmationEmail(ApplicationUser user) {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            token = HttpUtility.UrlEncode(token);

            var callbackUrl = $"https://localhost:7143/api/account/confirm-email?token={token}&email={user.Email}";
            //var callbackUrl = _generator.GetUriByPage(_accessor.HttpContext,
            //    page: "/Account/Confirm-Email",
            //    handler: null,
            //    values: new { token, email = user.Email });

            //var callbackUrl = _generator.GetUriByAction(_accessor.HttpContext,
            //    controller: "Account",
            //    action: "Confirm-Email",
            //    values: new { token, email = user.Email },
            //    scheme: _accessor.HttpContext.Request.Scheme,
            //    host: _accessor.HttpContext.Request.Host);

            await _emailService.SendEmailAsync(user.Email, "Confirm your account",
                $"Hi {user.UserName}!<br>You have been sent this email because you created an account on kinopoisk.<br>Please confirm your account by clicking this link: <a href=\"{callbackUrl}\">link</a>");
        }
    }
}
