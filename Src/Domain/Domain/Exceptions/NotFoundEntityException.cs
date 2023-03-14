#region UsingAndNamespace
namespace Domain.Exceptions; 
#endregion

public class NotFoundEntityException:BaseException
{
    public NotFoundEntityException(List<string> messages) : base(messages)
    {
    }

    public NotFoundEntityException(string message) : base(message)
    {
    }

    public NotFoundEntityException():base("موردی یافت نشد")
    {
        
    }
}