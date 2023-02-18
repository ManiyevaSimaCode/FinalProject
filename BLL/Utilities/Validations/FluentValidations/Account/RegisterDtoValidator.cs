﻿using Entities.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities.Validations.FluentValidations.Account
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty()
                .WithMessage("Don't Enter Empty ")
            .NotNull()
             .WithMessage("Don't Enter Null ")
               .MinimumLength(5).
                MaximumLength(255).
                Must(ValidName)
                .WithMessage("Enter valid  Name ");
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Don't Enter Empty ")
                .NotNull()
             .WithMessage("Don't Enter Null ")
               .MinimumLength(25).
                MaximumLength(255);
               
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
    {
    }
}
