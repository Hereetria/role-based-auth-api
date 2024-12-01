using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Validations.ValidationServices
{
    public interface IValidatorService
    {
        Task<ValidationResult> ValidateAsync<T>(T dto);
    }
}
