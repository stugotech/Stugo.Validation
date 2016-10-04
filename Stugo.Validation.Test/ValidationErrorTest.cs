using Xunit;

namespace Stugo.Validation.Test
{
    public class ValidationErrorTest
    {
        [Fact]
        public void AddPrefix_returns_args_separated_with_dot()
        {
            var result = ValidationError.AddPrefix("one", "two");
            Assert.Equal("one.two", result);
        }


        [Fact]
        public void AddPrefix_doesnt_write_dot_for_null_prefix()
        {
            var result = ValidationError.AddPrefix(null, "two");
            Assert.Equal("two", result);
        }


        [Fact]
        public void AddPrefix_doesnt_write_dot_for_empty_prefix()
        {
            var result = ValidationError.AddPrefix(null, "two");
            Assert.Equal("two", result);
        }


        [Fact]
        public void AddPrefix_doesnt_write_dot_for_null_field()
        {
            var result = ValidationError.AddPrefix("one", null);
            Assert.Equal("one", result);
        }


        [Fact]
        public void AddPrefix_doesnt_write_dot_for_empty_field()
        {
            var result = ValidationError.AddPrefix("one", null);
            Assert.Equal("one", result);
        }
    }
}
