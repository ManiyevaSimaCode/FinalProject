using BLL.Abstract;
using BLL.Utilities.Validations.FluentValidations.Category;
using BLL.Utilities.Validations.FluentValidations.Parameter;
using Entities.DTOs.Parameter;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace SimRaMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ParameterController : Controller
    {
        private readonly IParameterService _parameterService;
        public ParameterController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ParameterGetDto> parameters = await _parameterService.GetAllAsync();
            return View(parameters);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ParameterPostDto parameterPostDto)
        {
            ParameterPostDtoValidator parameterValidator = new ParameterPostDtoValidator();
            ValidationResult result = parameterValidator.Validate(parameterPostDto);
            if (result.IsValid)
            {
                await _parameterService.CreateAsync(parameterPostDto);
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
            ParameterUpdateDto parameterUpdateDto = new ParameterUpdateDto
            {
                ParameterGetDto = await _parameterService.GetByIdAsync(id),
            };
            return View(parameterUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ParameterUpdateDto parameterUpdateDto)
        {
            await _parameterService.UpdateAsync(parameterUpdateDto.ParameterGetDto.Id, parameterUpdateDto.ParameterPostDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            ParameterGetDto parameter = await _parameterService.GetByIdAsync(id);
            if (parameter is null)
            {
                return NotFound();
            }
            await _parameterService.DeleteByIdAsync(id);
            return Ok();

        }
    }
}
