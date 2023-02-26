using Microsoft.AspNetCore.Mvc;

namespace SimRaMVC.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
