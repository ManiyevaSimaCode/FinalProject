using BLL.Abstract;
using Entities.DTOs.Company;
using Microsoft.AspNetCore.Mvc;

namespace SimRaMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CompanyController : Controller
    {

        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CompanyGetDto> companies = await _companyService.GetAllAsync();
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CompanyPostDto companyPostDto)
        {
            await _companyService.CreateAsync(companyPostDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            CompanyUpdateDto companyUpdateDto = new CompanyUpdateDto
            {
                CompanyGetDto = await _companyService.GetByIdAsync(id),
            };
            return View(companyUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyUpdateDto companyUpdateDto)
        {
            await _companyService.UpdateAsync(companyUpdateDto.CompanyGetDto.Id, companyUpdateDto.CompanyPostDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {

            await _companyService.DeleteByIdAsync(id);
            return RedirectToAction("Index");

        }

    }
}
