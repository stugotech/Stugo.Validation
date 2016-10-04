namespace Stugo.Validation.Errors
{
    public class StringLengthValidationError : ValidationError
    {
        public const string Key = "Validation_StringLength";


        public StringLengthValidationError(string field, int maxLength)
            : base(field, Key)
        {
            this.MaxLength = maxLength;
        }


        public int MaxLength { get; private set; }
    }
}
