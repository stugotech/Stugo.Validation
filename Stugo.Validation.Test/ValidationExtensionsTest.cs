using Moq;
using Xunit;

namespace Stugo.Validation.Test
{
    public class ValidationExtensionsTest
    {
        [Fact]
        public void IsValid_returns_true_if_there_are_no_errors()
        {
            var validatorMock = new Mock<IValidator<object>>();
            validatorMock.Setup(x => x.GetErrors(It.IsAny<object>()))
                .Returns(new ValidationError[0]);

            var result = ValidationExtensions.IsValid(validatorMock.Object, null);

            Assert.Equal(true, result);
        }


        [Fact]
        public void IsValid_returns_false_if_there_is_one_error()
        {
            var validatorMock = new Mock<IValidator<object>>();
            validatorMock.Setup(x => x.GetErrors(It.IsAny<object>()))
                .Returns(new ValidationError[] {
                    new ValidationError("one", "one")
                });

            var result = ValidationExtensions.IsValid(validatorMock.Object, null);

            Assert.Equal(false, result);
        }
    }
}
