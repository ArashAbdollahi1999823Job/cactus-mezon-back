using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.Basket.Query.BasketGet;
public class BasketGetQueryHandler:IRequestHandler<BasketGetQuery,Domain.Entities.BasketEntity.Basket>
{
    #region CtorAndInjection
    private readonly IBasketRepository _basketRepository;
    public BasketGetQueryHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }
    #endregion

    public async Task<Domain.Entities.BasketEntity.Basket> Handle(BasketGetQuery req, CancellationToken cancellationToken)
    {
        return await _basketRepository.BasketGetAsync(req.Id);
    }
}