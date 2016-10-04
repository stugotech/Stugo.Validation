using System.Collections.Generic;
using System.Text;

namespace Stugo.Validation
{
    public class ValidationError
    {
        public static string AddPrefix(string prefix, string field)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(prefix))
            {
                builder.Append(prefix);

                if (!string.IsNullOrEmpty(field))
                    builder.Append(".");
            }

            if (!string.IsNullOrEmpty(field))
                builder.Append(field);

            return builder.ToString();
        }


        public static readonly ValidationError[] None = new ValidationError[0];


        public ValidationError(string field, string errorKey)
        {
            this.Field = field ?? "";
            this.ErrorKey = errorKey;
        }


        public string Field { get; private set; }
        public string ErrorKey { get; private set; }
    }
}
