using MediatR;

namespace Application.Features.Account.Commands.UserDelete;
public class UserDeleteByPhoneNumberCommand:IRequest<bool>
{
    public string PhoneNumber { get; set; }

    public UserDeleteByPhoneNumberCommand(string phoneNumber)
    {
       PhoneNumber= phoneNumber;
    }
}