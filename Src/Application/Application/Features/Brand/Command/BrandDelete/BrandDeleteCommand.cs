using MediatR;
namespace Application.Features.Brand.Command.BrandDelete;
public class BrandDeleteCommand:IRequest<bool>
{
    public Guid Id { set; get; }

    public BrandDeleteCommand(Guid id)
    {
        Id = id;
    }
}