using MediatR;
namespace Application.Features.TypePicture.Command.TypePictureDelete;

public class TypePictureDeleteCommand:IRequest<bool>
{
    public long Id { get; set; }

    public TypePictureDeleteCommand(long id)
    {
        Id = id;
    }
}