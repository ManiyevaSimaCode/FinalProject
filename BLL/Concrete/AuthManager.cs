using Entities.DTOs.Account;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly IActionContextAccessor _ActionContextAccessor;
        private readonly IMapper _mapper;

        public AuthManager(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IActionContextAccessor actionContextAccessor, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ActionContextAccessor = actionContextAccessor;
            _mapper = mapper;
        }

        public async Task<bool>Login(LoginDto loginDto)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(loginDto.Email);
            if (appUser is null)
            {
                _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Email or Password is incorrect!");
                return false;
            }
            else
            {
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, loginDto.Password, true);
                return true;
            }
        }
        public async Task<bool> Register(RegisterDto registerDto)
        {
            AppUser existUser = await _userManager.FindByNameAsync(registerDto.UserName);
            if (existUser is not null)
            {
                _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "This UserName is already exist!");

                return false;
            }//this email is already exist?

            AppUser appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Description="",
                FacebookUrl="",
                InstagramUrl="",
                TwitterUrl="",
                LinkedinUrl="",
                ImagePath="",
                isCompany=false,
                


            };
            IdentityResult result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!result.Succeeded)
            {
                _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Login or Password is incorrect!");

                return false;
            }

            await _userManager.AddToRoleAsync(appUser, "Admin");
            return true;


        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
