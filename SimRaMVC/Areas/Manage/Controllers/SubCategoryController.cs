using BLL.Abstract;
using BLL.Utilities.Validations.FluentValidations.Subcategory;
using Entities.Concrete;
using Entities.DTOs.SubCategory;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace SimRaMVC.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SubCategoryGetDto> subCategories = await _subCategoryService.GetAllAsync();
           
            return View(subCategories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryPostDto subCategoryPostDto)
        {
          
                await _subCategoryService.CreateAsync(subCategoryPostDto);
                return RedirectToAction("Index");

        }


        public async Task<IActionResult> Update(int id)
        {
            SubCategoryUpdateDto subCategoryUpdateDto = new SubCategoryUpdateDto
            {
                subCategoryGetDto = await _subCategoryService.GetByIdAsync(id),
            };
            return View(subCategoryUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubCategoryUpdateDto subCategoryUpdateDto)
        {
            await _subCategoryService.UpdateAsync(subCategoryUpdateDto.subCategoryGetDto.Id, subCategoryUpdateDto.subCategoryPostDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {

            await _subCategoryService.DeleteByIdAsync(id);
            return RedirectToAction("Index");

        }
    }
}
