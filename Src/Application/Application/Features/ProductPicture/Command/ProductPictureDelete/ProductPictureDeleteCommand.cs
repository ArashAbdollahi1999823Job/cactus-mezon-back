using MediatR;

namespace Application.Features.ProductPicture.Command.ProductPictureDelete;

public class ProductPictureDeleteCommand:IRequest<bool>
{
    public long Id { get; set; }

    public ProductPictureDeleteCommand(long id)
    {
        Id = id;
    }
}