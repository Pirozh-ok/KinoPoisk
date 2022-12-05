using AutoMapper;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class UserService : IUserService {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<ApplicationUser> userManager, 
                            SignInManager<ApplicationUser> signInManager,
                            IMapper mapper,
                            IUnitOfWork unitOfWork) {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper; 
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> LoginAsync(LoginDTO dto) {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null) {
                return new ErrorResult(new List<string>() { UserResource.InvalidEmail }); 
            }

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.IsPersistent, false);

            if(result.Succeeded) {
                return new SuccessResult<GetUserDTO>(_mapper.Map<GetUserDTO>(user)); 
            }

            return new ErrorResult(new List<string>() { UserResource.InvalidPassword });
        }

        public async Task<Result> LogoutAsync() {
            await _signInManager.SignOutAsync();
            return new SuccessResult<string>(UserResource.UserLogout);
        }

        public async Task<Result> RegisterAsync(CreateUserDTO dto) {
            if(dto is null) {
                return new ErrorResult(new List<string> { UserResource.NullArgument}); 
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
            user.PhoneNumber = string.Empty;
            var result = await _userManager.CreateAsync(user, dto.Password);
 
            if (result.Succeeded) {
                await _signInManager.SignInAsync(user, false); 
                return new SuccessResult<GetUserDTO>(_mapper.Map<GetUserDTO>(user));
            }

            var errors = new List<string>();

            foreach(var error in result.Errors) {
                errors.Add(error.ToString()); 
            }

            return new ErrorResult(errors); 
        }
    }
}
