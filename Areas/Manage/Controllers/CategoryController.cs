using BLL.Abstract;
using Entities.Concrete;
using Entities.DTOs.Category;
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
            List<CategoryGetDto> categories = await _categoryService.GetAllAsync();
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
            await _categoryService.CreateAsync(categoryPostDto);
            return RedirectToAction("Index");

            //if (!ModelState.IsValid)
            //{
            //    return View(categoryPostDto);
            //}
            //var result = 
            //if (!result.success)
            //{
            //    modelstate.addmodelerror("", result.message);
            //    return redirecttoaction("index");

            //}
        }

        public async Task<IActionResult> Update(int id)
        {
            CategoryUpdateDto categoryUpdateDto = new CategoryUpdateDto
            {
                categoryGetDto = await _categoryService.GetByIdAsync(id),
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

            CategoryGetDto category = await _categoryService.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }

            await _categoryService.DeleteByIdAsync(id);
            
            return Ok();

        }



    }
}



