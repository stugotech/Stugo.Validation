using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Stugo.Validation.Validators
{
    public class EntityValidator<T> : IValidator<T>
    {
        private readonly List<IValidator<T>> validators = new List<IValidator<T>>();


        public EntityValidator<T> Validate<TProperty>(
            Expression<Func<T, TProperty>> propertyAccessor, 
            params IValidator<TProperty>[] validators)
        {
            this.validators.Add(
                new PropertyValidator<T, TProperty>(propertyAccessor, validators)
            );
            return this;
        }


        public ValidationError[] GetErrors(T entity, string prefix = null)
        {
            return validators.SelectMany(x => x.GetErrors(entity, prefix)).ToArray();
        }
    }
}
