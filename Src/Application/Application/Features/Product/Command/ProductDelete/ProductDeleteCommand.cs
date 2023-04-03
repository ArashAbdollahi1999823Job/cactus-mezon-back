using MediatR;

namespace Application.Features.Product.Command.ProductDelete;

public class ProductDeleteCommand:IRequest<bool>
{
    public long Id { set; get; }

    public ProductDeleteCommand(long id)
    {
        Id = id;
    }
}