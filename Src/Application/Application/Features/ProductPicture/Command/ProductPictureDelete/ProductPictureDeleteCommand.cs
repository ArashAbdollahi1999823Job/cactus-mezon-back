using MediatR;

namespace Application.Features.ProductPicture.Command.ProductPictureDelete;

public class ProductPictureDeleteCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public ProductPictureDeleteCommand(Guid id)
    {
        Id = id;
    }
}