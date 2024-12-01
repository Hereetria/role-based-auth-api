using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Validations.ValidationServices
{
    public class ValidatorService : IValidatorService
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<ValidationResult> ValidateAsync<T>(T dto)
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();

            if (validator == null)
            {
                throw new InvalidOperationException($"Validator for type {typeof(T).Name} not found.");
            }

            var validationResult = await validator.ValidateAsync(dto);
            return validationResult;
        }
    }
}
