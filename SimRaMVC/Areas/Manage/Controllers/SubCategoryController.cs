using BLL.Abstract;
using BLL.Utilities.Validations.FluentValidations.Subcategory;
using Entities.DTOs.SubCategory;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace SimRaMVC.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SubCategoryGetDto> subCategories = await _subCategoryService.GetAllAsync();
           
            return View(subCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryPostDto subCategoryPostDto)
        {
            SubCategoryPostDtoValidator subCategoryValidator = new SubCategoryPostDtoValidator();
            ValidationResult result = subCategoryValidator.Validate(subCategoryPostDto);
            if (result.IsValid)
            {
                await _subCategoryService.CreateAsync(subCategoryPostDto);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            }
            return View();

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
