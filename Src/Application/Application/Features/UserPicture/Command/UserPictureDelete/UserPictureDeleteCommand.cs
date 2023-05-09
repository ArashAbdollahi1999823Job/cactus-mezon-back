using MediatR;

namespace Application.Features.UserPicture.Command.UserPictureDelete;

public class UserPictureDeleteCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public UserPictureDeleteCommand(Guid id)
    {
        Id = id;
    }
}