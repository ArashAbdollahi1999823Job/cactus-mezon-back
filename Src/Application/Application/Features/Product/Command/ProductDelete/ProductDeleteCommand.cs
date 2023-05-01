using MediatR;

namespace Application.Features.Product.Command.ProductDelete;

public class ProductDeleteCommand:IRequest<bool>
{
    public Guid Id { set; get; }

    public ProductDeleteCommand(Guid id)
    {
        Id = id;
    }
}