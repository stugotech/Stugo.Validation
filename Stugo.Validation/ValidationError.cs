namespace Stugo.Validation
{
    public class ValidationError
    {
        public static readonly ValidationError[] None = new ValidationError[0];


        public ValidationError(string field, string errorKey)
        {
            this.Field = field;
            this.ErrorKey = errorKey;
        }


        public string Field { get; private set; }
        public string ErrorKey { get; private set; }
    }
}
