using Entities.DTOs.Product;

namespace BLL.Utilities.Validations.FluentValidations.Product
{
    public class ProductPostDtoValidator:AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Don't Enter Empty ")
            .NotNull()
             .WithMessage("Don't Enter Null ")
               .MinimumLength(5).
                MaximumLength(255).
                Must(ValidName)
                .WithMessage("Enter valid SubCategory Name ");
        }
        private bool ValidName(string name)
        {
            var nameRegex = "/^[A-Za-z ]+$/";
            Regex regex = new Regex(nameRegex);
            if (regex.IsMatch(name))
            {
                return true;
            }
            return false;
        }
    }
}
