using MediatR;

namespace Application.Features.Account.Commands.UserVerifyDelete;
public class UserVerifyDeleteByPhoneNumberCommand:IRequest<bool>
{
    public string PhoneNumber { get; set; }

    public UserVerifyDeleteByPhoneNumberCommand(string phoneNumber)
    {
       PhoneNumber= phoneNumber;
    }
}