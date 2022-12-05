using AutoMapper;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.PresentationLayer;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class UserService : IUserService {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager; 
        private readonly IAuthService _jwtService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<ApplicationUser> userManager,
                            IAuthService jwtService,
                            IMapper mapper,
                            IUnitOfWork unitOfWork,
                            RoleManager<ApplicationRole> roleManager) {
            _userManager = userManager;
            _jwtService = jwtService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
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

        public async Task<Result> LogoutAsync() {
            //await _signInManager.SignOutAsync();
            return new SuccessResult<string>(UserResource.UserLogout);
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

            // проверка почты на корректность и принадлежность пользователю?? 

            var user = _mapper.Map<ApplicationUser>(dto);
            user.PhoneNumber = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded) {
                var role = await _roleManager.FindByNameAsync("User");
                _userManager.AddToRoleAsync(user, role.Name); 

                return new SuccessResult<AuthResponseDTO<GetUserDTO>>(await GetAuthResult(user));
            }

            var errors = new List<string>();

            foreach (var error in result.Errors) {
                errors.Add(error.ToString());
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
    }
}
