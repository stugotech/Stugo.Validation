using Moq;
using Stugo.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stugo.Validation.Test.Validators
{
    public class PropertyValidatorTest
    {
        [Fact]
        public void GetErrors_calls_child_validators_with_correct_field_name()
        {
            var value = new Tuple<int, int>(1, 2);
            var validatorMock = new Mock<IValidator<int>>();

            Expression<Func<IValidator<int>, ValidationError[]>> getErrorCall =
                x => x.GetErrors(
                    It.Is<int>(v => v == value.Item1),
                    It.Is<string>(p => p == "Root.Item1")
                );

            validatorMock.Setup(getErrorCall).Returns(new ValidationError[0]);

            var propValidator = new PropertyValidator<Tuple<int, int>, int>(
                x => x.Item1, validatorMock.Object);

            propValidator.GetErrors(value, "Root");
            validatorMock.Verify(getErrorCall, Times.Once);
        }
    }
}
