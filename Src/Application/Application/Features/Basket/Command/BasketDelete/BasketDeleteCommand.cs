#region UsingAndNamespace
using MediatR;
namespace Application.Features.Basket.Command.BasketDelete;
#endregion
public class BasketDeleteCommand:IRequest<bool>
{
    public string Id { get; set; }

    public BasketDeleteCommand(string id)
    {
        Id = id;
    }
}