using FluentValidation;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Validations.UserValidations
{
    public class SignUpUserValidator : AbstractValidator<SignUpUserDto>
    {
        public SignUpUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 100).WithMessage("Username must be between 3 and 100 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.UserName)); ;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"\d").WithMessage("Password must contain at least one digit.")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.")
                .Matches(@"^\S+$").WithMessage("Password must not contain spaces.");

            RuleFor(x => x.PasswordConfirm)
                .NotEmpty().WithMessage("Password confirmation is required.")
                .Equal(x => x.Password).WithMessage("Passwords do not match.");


            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .Length(3, 100).WithMessage("Full Name must be between 3 and 100 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.FullName)); ;

            RuleFor(x => x.Bio)
                .MaximumLength(500).WithMessage("Bio must not exceed 500 characters.");

            RuleFor(x => x.ProfilePicture)
                .MaximumLength(500).WithMessage("Profile picture URL must not exceed 500 characters.");
        }
    }
}
