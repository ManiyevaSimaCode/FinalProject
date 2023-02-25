using Entities.DTOs.Account;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._ActionContextAccessor = actionContextAccessor;
            this._mapper = mapper;
        }
        public AuthManager()
        {
                
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Email or Password is incorrect!");
                return false;
            }
            // FindByEmailAsync
            AppUser appUser = await _userManager.FindByEmailAsync(loginDto.Email);
       
            if (appUser == null)
            {

                _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Email or Password is incorrect!");
                return false;

            }
            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, loginDto.Password, loginDto.RememberMe, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Your account is blocked for 5 minutes");
                    return false;
                }

                _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Email or Password is incorrect!");
                return false;


            }
            return true;

        }
        public async Task<bool> Register(RegisterDto registerDto)
        {
            //AppUser existUser = await _userManager.FindByEmailAsync(registerDto.Email);

            AppUser appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Description = "",
                FacebookUrl = "",
                InstagramUrl = "",
                TwitterUrl = "",
                LinkedinUrl = "",
                ImagePath = "",
                isCompany = false,



            };
            IdentityResult result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    _ActionContextAccessor.ActionContext.ModelState.AddModelError("", item.Description);
                    return false;

                }
            }

            await _userManager.AddToRoleAsync(appUser, "User");
            return true;


        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
