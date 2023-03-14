using Application.Common.Messages;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Basket.Command.BasketItemDelete;
public class BasketItemDeleteCommandHandler : IRequestHandler<BasketItemDeleteCommand, Domain.Entities.BasketEntity.Basket>
{
    #region CtorAndInjection
    private readonly IBasketRepository _basketRepository;
    public BasketItemDeleteCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }
    #endregion

    public async Task<Domain.Entities.BasketEntity.Basket> Handle(BasketItemDeleteCommand req,
        CancellationToken cancellationToken)
    {
        var basket = await _basketRepository.BasketGetAsync(req.BasketId);
        if (basket == null) throw new NotFoundEntityException(ApplicationMessages.BasketNotFound);
        var item = basket.BasketItems.FirstOrDefault(x => x.Id == req.ItemId);
        basket.BasketItems.Remove(item);
        if (basket.BasketItems.Count == 0) await _basketRepository.BasketDeleteAsync(req.BasketId);
        else await _basketRepository.BasketEditAsync(basket);
        basket.BasketItems = basket.BasketItems.ToList();
        return basket;
    }
}