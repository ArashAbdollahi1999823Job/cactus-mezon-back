using MediatR;
namespace Application.Features.Brand.Command.BrandDelete;
public class BrandDeleteCommand:IRequest<bool>
{
    public long Id { set; get; }

    public BrandDeleteCommand(long id)
    {
        Id = id;
    }
}