using MediatR;
namespace Application.Features.TypePicture.Command.TypePictureDelete;

public class TypePictureDeleteCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public TypePictureDeleteCommand(Guid id)
    {
        Id = id;
    }
}