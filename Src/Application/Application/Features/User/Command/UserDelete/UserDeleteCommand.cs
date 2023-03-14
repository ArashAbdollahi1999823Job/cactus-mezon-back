using MediatR;
namespace Application.Features.User.Command.UserDelete;
public class UserDeleteCommand:IRequest<bool>
{
    public string id { get; set; }

    public UserDeleteCommand(string id)
    {
        this.id = id;
    }
}