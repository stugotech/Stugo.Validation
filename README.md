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
ValidationError[] GetErrors(T entity);
```

## Bundled validators 

For convenience, a few validators are provided.

| Validator | Error | Information error fields |
|---|---|---|
| `RequiredValidator` | `RequiredValidationError` | |
| `StringLengthValidator` | `StringLengthValidationError` | `MaxLength` |


## Compound validators 

### PropertyValidator

This validator will call a number of child validators with a value provided by a property accessor
expression:

```csharp
var validator = new PropertyValidator<MyClass>(
    x => x.MyProperty, 
	new RequiredValidator(), 
	new StringLengthValidator(10)
);
```


### EntityValidator

This validator allows chaining of multiple validators together:

```csharp
var entityValidator = new EntityValidator<MyClass>()
    .Validate(x => x.Item1, new RequiredValidator(), new StringLengthValidator(5))
    .Validate(x => x.Item2, new RequiredValidator(), new StringLengthValidator(3));
```