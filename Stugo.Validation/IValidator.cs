using System.Collections.Generic;

namespace Stugo.Validation
{
    public interface IValidator<T>
    {
        ValidationError[] GetErrors(T entity, string prefix = null);
    }
}
