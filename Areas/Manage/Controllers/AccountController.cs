using BLL.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SimRaMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            var result = await _authService.Login(loginDto);
            if (!result)
            {
                return View(loginDto);
            }

            return RedirectToAction("Index", "Home", new { area = "Manage" });
        }


        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _authService.SignOut();
            return RedirectToAction("Login", "Account");
        }
    
    }
}
