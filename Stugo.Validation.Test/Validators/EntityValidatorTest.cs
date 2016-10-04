using Stugo.Validation.Errors;
using Stugo.Validation.Validators;
using System;
using Xunit;

namespace Stugo.Validation.Test.Validators
{
    public class EntityValidatorTest
    {
        [Fact]
        public void GetErrors_runs_the_configured_validators()
        {
            var entityValidator = new EntityValidator<Tuple<string, string>>()
                .Validate(x => x.Item1, new RequiredValidator(), new StringLengthValidator(5))
                .Validate(x => x.Item2, new RequiredValidator(), new StringLengthValidator(3));

            var value = new Tuple<string, string>("1234567", "");
            var errors = entityValidator.GetErrors(value);

            Assert.Collection(errors,
                x =>
                {
                    Assert.IsType<StringLengthValidationError>(x);
                    Assert.Equal("Item1", x.Field);
                    Assert.Equal(5, ((StringLengthValidationError)x).MaxLength);
                },
                x =>
                {
                    Assert.IsType<RequiredValidationError>(x);
                    Assert.Equal("Item2", x.Field);
                }
            );
        }
    }
}
