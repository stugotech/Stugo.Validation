using Stugo.Validation.Errors;
using Stugo.Validation.Validators;
using System.Linq;
using Xunit;

namespace Stugo.Validation.Test.Validators
{
    public class StringLengthValidatorTest
    {
        [Fact]
        public void GetErrors_returns_no_error_for_null()
        {
            var validator = new StringLengthValidator(10);

            var errors = validator.GetErrors(null).ToArray();

            Assert.Equal(0, errors.Length);
        }


        [Fact]
        public void GetErrors_returns_no_error_for_empty()
        {
            var validator = new StringLengthValidator(10);

            var errors = validator.GetErrors(string.Empty).ToArray();

            Assert.Equal(0, errors.Length);
        }


        [Fact]
        public void GetErrors_returns_no_error_for_length_less_than_max()
        {
            var validator = new StringLengthValidator(10);

            var errors = validator.GetErrors("12345678").ToArray();

            Assert.Equal(0, errors.Length);
        }


        [Fact]
        public void GetErrors_returns_no_error_for_length_equal_to_max()
        {
            var validator = new StringLengthValidator(10);

            var errors = validator.GetErrors("1234567890").ToArray();

            Assert.Equal(0, errors.Length);
        }


        [Fact]
        public void GetErrors_returns_error_for_length_greater_than_max()
        {
            var validator = new StringLengthValidator(10);

            var errors = validator.GetErrors("12345678901").ToArray();

            Assert.Equal(1, errors.Length);

            var error = errors[0];
            Assert.IsType<StringLengthValidationError>(error);
            Assert.Equal(10, ((StringLengthValidationError)error).MaxLength);
        }
    }
}
