using BLL.Abstract;
using BLL.Utilities.Validations.FluentValidations.Category;
using Entities.DTOs.Category;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace SimRaMVC.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
         
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CategoryGetDto>categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
         public async Task<IActionResult> Create(CategoryPostDto categoryPostDto)
        {
            CategoryPostDtoValidator categoryValidator = new CategoryPostDtoValidator();
            ValidationResult result = categoryValidator.Validate(categoryPostDto);
            if (result.IsValid)
            {
                await _categoryService.CreateAsync(categoryPostDto);
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

       
        public  async Task<IActionResult> Update(int id)
        {
            CategoryUpdateDto categoryUpdateDto = new CategoryUpdateDto
            {
                categoryGetDto =await _categoryService.GetByIdAsync(id),
            };
            return View(categoryUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            await _categoryService.UpdateAsync(categoryUpdateDto.categoryGetDto.Id, categoryUpdateDto.categoryPostDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {

            await _categoryService.DeleteByIdAsync(id);
            return RedirectToAction("Index");

        }



    }
}
