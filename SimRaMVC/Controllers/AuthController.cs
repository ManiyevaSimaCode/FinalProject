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

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            var result = await _authService.Register(registerDto);
            if (!result)
            {
                return RedirectToAction("Register",registerDto);
            }

            return RedirectToAction("Login",registerDto);
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


        [HttpGet]
        public IActionResult SignOut()
        {
            return RedirectToAction("Login", "Auth");
        }

    }
}
