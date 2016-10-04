using Stugo.Validation.Errors;
using Stugo.Validation.Validators;
using System.Linq;
using Xunit;

namespace Stugo.Validation.Test.Validators
{
    public class RequiredValidatorTest
    {
        [Fact]
        public void GetErrors_returns_an_error_on_null()
        {
            var validator = new RequiredValidator();

            var errors = validator.GetErrors(null).ToArray();

            Assert.Equal(1, errors.Length);
            Assert.IsType<RequiredValidationError>(errors[0]);
        }


        [Fact]
        public void GetErrors_returns_an_error_on_empty_string()
        {
            var validator = new RequiredValidator();

            var errors = validator.GetErrors(string.Empty).ToArray();

            Assert.Equal(1, errors.Length);
            Assert.IsType<RequiredValidationError>(errors[0]);
        }


        [Fact]
        public void GetErrors_returns_an_error_on_empty_array()
        {
            var validator = new RequiredValidator();

            var errors = validator.GetErrors(new int[] { }).ToArray();

            Assert.Equal(1, errors.Length);
            Assert.IsType<RequiredValidationError>(errors[0]);
        }


        [Fact]
        public void GetErrors_returns_no_errors_on_non_empty_string()
        {
            var validator = new RequiredValidator();

            var errors = validator.GetErrors("hello").ToArray();

            Assert.Equal(0, errors.Length);
        }


        [Fact]
        public void GetErrors_returns_no_errors_on_integer()
        {
            var validator = new RequiredValidator();

            var errors = validator.GetErrors(1).ToArray();

            Assert.Equal(0, errors.Length);
        }


        [Fact]
        public void GetErrors_returns_no_errors_on_non_empty_array()
        {
            var validator = new RequiredValidator();

            var errors = validator.GetErrors(new[] { 1 }).ToArray();

            Assert.Equal(0, errors.Length);
        }
    }
}
