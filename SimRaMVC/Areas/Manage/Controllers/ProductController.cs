using BLL.Abstract;
using Entities.DTOs.Product;
using Microsoft.AspNetCore.Mvc;

namespace SimRaMVC.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IParameterService _parameterService;


        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public  async Task<IActionResult> Index()
        {
            List<ProductGetDto> products = await _productService.GetAllAsync();

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProductPostDto productPostDto)
        {

            await _productService.CreateAsync(productPostDto);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Update(int id)
        {
            ProductUpdateDto productUpdateDto = new ProductUpdateDto
            {
                ProductGetDto = await _productService.GetByIdAsync(id),
            };
            ViewBag.Categories = await _categoryService.GetAllAsync();
            ViewBag.Parameters = await _parameterService.GetAllAsync();
            return View(productUpdateDto);
        }


        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateAsync(productUpdateDto.ProductGetDto.Id, productUpdateDto.ProductPostDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {


            ProductGetDto product = await _productService.GetByIdAsync(id);
            if (product is null)
            {
                return RedirectToAction("Error", "Home");
            }

            await _productService.DeleteByIdAsync(id);

            return Ok();


        }


    }
}
