namespace Stugo.Validation.Errors
{
    public class RequiredValidationError : ValidationError
    {
        public const string Key = "Validation_Required";

        public RequiredValidationError(string field)
            : base(field, Key)
        {
        }


        public RequiredValidationError()
            : this("value")
        {
        }
    }
}
