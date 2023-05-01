using MediatR;

namespace Application.Features.ProductItem.Command.ProductItemDelete;

public class ProductItemDeleteCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public ProductItemDeleteCommand(Guid id)
    {
        Id = id;
    }
}