using Stugo.Validation.Errors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stugo.Validation.Validators
{
    public class RequiredValidator : IValidator<object>
    {
        public IEnumerable<ValidationError> GetErrors(object value, string prefix = null)
        {
            if (value == null
                || (value is string && string.IsNullOrEmpty((string)value))
                || (value is IEnumerable && !((IEnumerable)value).GetEnumerator().MoveNext()))
            {
                return new ValidationError[] { new RequiredValidationError(prefix) };
            }
            else
            {
                return ValidationError.None;
            }
        }
    }
}
