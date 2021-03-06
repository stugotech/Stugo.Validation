﻿using Stugo.Validation.Errors;
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


        public ValidationError[] GetErrors(string entity, string prefix = null)
        {
            if (entity != null && entity.Length > maxLength)
                return new[] { new StringLengthValidationError(prefix, maxLength) };
            else
                return ValidationError.None;
        }
    }
}
