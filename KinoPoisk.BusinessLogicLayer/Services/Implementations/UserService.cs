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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Security.Principal;
using System.Web;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class UserService : IUserService {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _jwtService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public UserService(UserManager<ApplicationUser> userManager,
            IAuthService jwtService,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IEmailService emailService) {
            _userManager = userManager;
            _jwtService = jwtService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task<Result> LoginAsync(LoginDTO dto) {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null) {
                return new ErrorResult(new List<string>() { UserResource.InvalidEmail });
            }

            if (await _userManager.CheckPasswordAsync(user, dto.Password)) {
                return new SuccessResult<AuthResponseDTO<GetUserDTO>>(await GetAuthResult(user));
            }

            return new ErrorResult(new List<string>() { UserResource.InvalidPassword });
        }

        public async Task<Result> RegisterAsync(CreateUserDTO dto, IUrlHelper url, string scheme) {
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
                await SendConfirmationEmail(user, url, scheme);
                return new SuccessResult<AuthResponseDTO<GetUserDTO>>(await GetAuthResult(user));
            }

            var errors = new List<string>();

            foreach (var error in result.Errors) {
                errors.Add(error.Description.ToString());
            }

            return new ErrorResult(errors);
        }

        public async Task ConfirmEmailAsync(string userEmail, IUrlHelper url, string scheme) {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user.EmailConfirmed) {
                return; 
            }

            await SendConfirmationEmail(user, url, scheme);
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

        private async Task SendConfirmationEmail(ApplicationUser user, IUrlHelper url, string scheme) {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            token = HttpUtility.UrlEncode(token); 
            //var callbackUrl = url.Action(
            //            action: "Confirm-email",
            //            controller: "Account",
            //            values: new { token, email = user.Email },
            //            protocol: scheme,
            //            host : "localhost:7143"
            //            );
            var callbackUrl = $"{scheme}://localhost:7143/api/account/confirm-email?token={token}&email={user.Email}";
            await _emailService.SendEmailAsync(user.Email, "Confirm your account",
                $"Hi {user.UserName}\n. You have been sent this email because you created an account on kinopoisk. \nPlease confirm your account by clicking this link: <a href=\"{callbackUrl}\">link</a>");
        }
    }
}
