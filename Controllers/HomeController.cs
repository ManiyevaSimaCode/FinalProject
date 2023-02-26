using BLL.Abstract;
using Entities.DTOs.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimRaMVC.Models;
using System.Diagnostics;

namespace SimRaMVC.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IProductService _productService;

        public HomeController(ICompanyService companyService, IProductService productService)
        {
            _companyService = companyService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM
            {
                Companies = await _companyService.GetAllAsync(),
                //Products = await _productService.GetAllAsync(),
                //Product = await _productService.GetByIdAsync();
            };
            return View(vm);
        }


        public IActionResult ErrorPage()
        {
            return View();
        }


    }
}