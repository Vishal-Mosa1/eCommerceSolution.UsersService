using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format");
        //Password
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required")
        .MinimumLength(8).WithMessage("Password should be of minimum length 8");
        //PersonName
        RuleFor(temp => temp.PersonName).Length(1, 50).WithMessage("Person name should be 1 to 50 characters long");
        //Gender
        RuleFor(temp => temp.Gender).IsInEnum().WithMessage("Gender should be a valid male, female or others");
    }
}
