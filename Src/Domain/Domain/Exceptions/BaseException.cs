#region UsignAndNamespace

using FluentValidation.Results;

namespace Domain.Exceptions; 
#endregion

public class BaseException:Exception
{
    #region Properties
    public List<string> Messages { get; set; }
    #endregion

    #region Ctors
    public BaseException(List<string> messages) : base(null)
    {
        Messages = messages;
    }
    public BaseException(string message) : base(message)
    {

    }

    public BaseException(IEnumerable<ValidationFailure> validationFailures)
    {
        Messages = validationFailures.Select(x => x.ErrorMessage).ToList();
    }
    #endregion
}