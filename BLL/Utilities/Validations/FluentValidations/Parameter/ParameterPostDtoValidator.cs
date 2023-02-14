using Entities.DTOs.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities.Validations.FluentValidations.Parameter
{
    public class ParameterPostDtoValidator : AbstractValidator<ParameterPostDto>
    {
        public ParameterPostDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Don't Enter Empty ")
            .NotNull()
             .WithMessage("Don't Enter Null ")
               .MinimumLength(5).
                MaximumLength(255).
                Must(ValidName)
                .WithMessage("Enter valid Parameter");
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
