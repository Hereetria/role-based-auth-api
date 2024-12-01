using FluentValidation;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Validations.UserValidations
{
    public class LoginUserValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 100).WithMessage("Username must be between 3 and 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.UserName));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .When(x => !string.IsNullOrEmpty(x.Password)); ;
        }
    }
}
