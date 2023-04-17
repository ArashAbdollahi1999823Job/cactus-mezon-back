using MediatR;

namespace Application.Features.ProductItem.Command.ProductItemDelete;

public class ProductItemDeleteCommand:IRequest<bool>
{
    public long Id { get; set; }

    public ProductItemDeleteCommand(long id)
    {
        Id = id;
    }
}