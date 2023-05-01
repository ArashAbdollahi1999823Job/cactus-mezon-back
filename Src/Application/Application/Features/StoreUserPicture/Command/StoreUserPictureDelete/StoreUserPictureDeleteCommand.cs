using MediatR;
namespace Application.Features.StoreUserPicture.Command.StoreUserPictureDelete;
public class StoreUserPictureDeleteCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public StoreUserPictureDeleteCommand(Guid id)
    {
        Id = id;
    }
}