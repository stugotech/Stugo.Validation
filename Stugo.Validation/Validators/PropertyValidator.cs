using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Stugo.Validation.Validators
{
    public class PropertyValidator<TEntity, TProperty> : IValidator<TEntity>
    {
        private readonly string propertyName;
        private readonly Func<TEntity, TProperty> propertyAccessor;
        private readonly IValidator<TProperty>[] validators;


        public PropertyValidator(Expression<Func<TEntity, TProperty>> propertyAccessor,
            params IValidator<TProperty>[] validators)
        {
            if (!(propertyAccessor.Body is MemberExpression))
                throw new ArgumentException($"{nameof(propertyAccessor)} must be a member expression");

            this.validators = validators;
            this.propertyName = ((MemberExpression)propertyAccessor.Body).Member.Name;
            this.propertyAccessor = propertyAccessor.Compile();
        }


        public ValidationError[] GetErrors(TEntity entity, string prefix = null)
        {
            return validators.SelectMany(
                x => x.GetErrors(
                    propertyAccessor(entity),
                    ValidationError.AddPrefix(prefix, propertyName)
                )
            ).ToArray();
        }
    }
}
