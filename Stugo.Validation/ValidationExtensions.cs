using System.Collections.Generic;
using System.Linq;

namespace Stugo.Validation
{
    public static class ValidationExtensions
    {
        public static bool IsValid<T>(this IValidator<T> validator, T entity)
        {
            return !validator.GetErrors(entity).Any();
        }


        public static IDictionary<string, ValidationError[]> ToErrorDictionary(this IEnumerable<ValidationError> src)
        {
            return src.GroupBy(x => x.Field)
                .ToDictionary(grp => grp.Key, grp => grp.ToArray());
        }
    }
}
