using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace SimRaMVC.Controllers
{
    public class HomeController : Controller
    {
  

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

   
    }
}