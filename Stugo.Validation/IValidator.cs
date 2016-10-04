using System.Collections.Generic;

namespace Stugo.Validation
{
    public interface IValidator<T>
    {
        IEnumerable<ValidationError> GetErrors(T entity, string prefix = null);
    }
}
