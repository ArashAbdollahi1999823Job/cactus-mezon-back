using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.Basket.Command.BasketDelete;
public class BasketDeleteCommandHandler:IRequestHandler<BasketDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IBasketRepository _basketRepository;
    public BasketDeleteCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }
    #endregion
    public async Task<bool> Handle(BasketDeleteCommand req, CancellationToken cancellationToken)
    {
        return await _basketRepository.BasketDeleteAsync(req.Id);
    }
}