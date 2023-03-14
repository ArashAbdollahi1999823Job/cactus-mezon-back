using MediatR;

namespace Application.Features.Basket.Command.BasketEdit;
public class BasketEditCommand:IRequest<Domain.Entities.BasketEntity.Basket>
{
    public Domain.Entities.BasketEntity.Basket Basket { get; set; }

    public BasketEditCommand(Domain.Entities.BasketEntity.Basket basket)
    {
       Basket = basket;
    }
}