using BLL.Abstract;
using Entities.DTOs.Account;
using Microsoft.AspNetCore.Mvc;

namespace SimRaMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(IAuthService authService/*RoleManager<IdentityRole> roleManager*/)
        {
            _authService = authService;
            //_roleManager = roleManager;
        }

        //public async  Task<IActionResult> Index()
        //{

        //   await  _roleManager.CreateAsync(new IdentityRole("Admin"));
        //   await  _roleManager.CreateAsync(new IdentityRole("User"));
        //    return Json("ok");
        //}


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            var result = await _authService.Register(registerDto);
            if (!result)
            {
                return View(registerDto);
            }

            return RedirectToAction(nameof(Login));
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

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _authService.SignOut();
            return RedirectToAction("Login", "Auth");
        }

    }
}
