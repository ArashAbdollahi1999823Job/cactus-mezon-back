#region UsingAndNamespace

using FluentValidation.Results;

namespace Domain.Exceptions; 
#endregion

public class ValidationEntityException:BaseException
{
    public ValidationEntityException(List<string> messages) : base(messages)
    {
    }

    public ValidationEntityException(string message) : base(message)
    {
    }

    public ValidationEntityException():base("خطلایی رخ داده است")
    {
        
    }

    public ValidationEntityException(IEnumerable<ValidationFailure> validationFailures):base(validationFailures)
    {
        
    }
}