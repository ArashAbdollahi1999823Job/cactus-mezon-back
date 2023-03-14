using MediatR;

namespace Application.Features.Basket.Command.BasketItemDelete;

public class BasketItemDeleteCommand:IRequest<Domain.Entities.BasketEntity.Basket>
{
    public string BasketId { set; get; }
    public long ItemId { set; get; }

    public BasketItemDeleteCommand(string basketId, long itemId)
    {
        BasketId = basketId;
        ItemId = itemId;
    }
}