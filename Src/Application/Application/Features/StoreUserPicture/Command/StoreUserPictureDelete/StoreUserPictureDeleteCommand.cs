using MediatR;
namespace Application.Features.StoreUserPicture.Command.StoreUserPictureDelete;
public class StoreUserPictureDeleteCommand:IRequest<bool>
{
    public long Id { get; set; }

    public StoreUserPictureDeleteCommand(long id)
    {
        Id = id;
    }
}