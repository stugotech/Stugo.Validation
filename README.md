# Stugo.Validation

This library provides some utilities for validating values in C#.


## ValidationError

The `ValidationError` class represents an error with a field of an entity.

```csharp
public class ValidationError
{
	public ValidationError(string field, string errorKey) { /* ... */ }
    public string Field { get; private set; }
    public string ErrorKey { get; private set; }
}
```

It is expected that specific kinds of validation error are derived from the `ValidationError` class
as with the provided `StringLengthValidationError` class:

```csharp
public class StringLengthValidationError : ValidationError
{
    public const string Key = "Validation_StringLength";


    public StringLengthValidationError(string field, int maxLength)
        : base(field, Key)
    {
        this.MaxLength = maxLength;
    }


    public StringLengthValidationError(int maxLength)
        : this("value", maxLength)
    {
    }


    public int MaxLength { get; private set; }
}
```

It is suggested that the localised string corresponding to the `ErrorKey` could have placeholders 
for the extra properties (in this case `MaxLength`).



## IValidator 

All validators are based on `IValidator<T>` which has one method:

```csharp
IEnumerable<ValidationError> GetErrors(T entity);
```

## Bundled validators 

For convenience, a few validators are provided.

| Validator | Error | Information error fields |
|---|---|---|
| `RequiredValidator` | `RequiredValidationError` | |
| `StringLengthValidator` | `StringLengthValidationError` | `MaxLength` |


## A note on generator functions

It might seem convenient to implement a validation function as follows:

```csharp
public IEnumerable<ValidationError> GetErrors(object value)
{
    if (value == null
        || (value is string && string.IsNullOrEmpty((string)value))
        || (value is IEnumerable && !((IEnumerable)value).GetEnumerator().MoveNext()))
    {
        yield return new RequiredValidationError();  // DON'T DO THIS!
    }
}
```

**DON'T.**  A callee might assume they have a list of validation errors, but actually every time
the list is enumerated, the entity will be re-validated, which probably isn't what is expected.