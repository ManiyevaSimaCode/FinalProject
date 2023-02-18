using Entities.DTOs.Account;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly IActionContextAccessor _ActionContextAccessor;

        public AuthManager(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IActionContextAccessor actionContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ActionContextAccessor = actionContextAccessor;
        }

        public async Task<bool>Login(LoginDto loginDto)
        {
            AppUser appUser = await _userManager.FindByNameAsync(loginDto.UserName);
            if (appUser is null)
            {
                _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Login or Password is incorrect!");
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
            AppUser appUser = new AppUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
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
