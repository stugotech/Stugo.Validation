using Stugo.Validation.Errors;
using System.Collections.Generic;

namespace Stugo.Validation.Validators
{
    public class StringLengthValidator : IValidator<string>
    {
        private readonly int maxLength;


        public StringLengthValidator(int maxLength)
        {
            this.maxLength = maxLength;
        }


        public IEnumerable<ValidationError> GetErrors(string entity)
        {
            if (entity != null && entity.Length > maxLength)
                return new[] { new StringLengthValidationError(maxLength) };
            else
                return ValidationError.None;
        }
    }
}
