using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.Basket.Command.BasketEdit;
public class BasketEditCommandHandler:IRequestHandler<BasketEditCommand,Domain.Entities.BasketEntity.Basket>
{
    #region CtorAndInjection
    private readonly IBasketRepository _basketRepository;
    public BasketEditCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }
    #endregion
    
    public async Task<Domain.Entities.BasketEntity.Basket> Handle(BasketEditCommand req, CancellationToken cancellationToken)
    {
      return  await _basketRepository.BasketEditAsync(req.Basket);
    }
}   