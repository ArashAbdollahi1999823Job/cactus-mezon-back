using Domain.Entities.BasketEntity;
namespace Application.IContracts.IRepository;
public interface IBasketRepository
{
    Task<Basket> BasketGetAsync(string id);
    Task<Basket> BasketEditAsync(Basket basket);
    Task<bool> BasketDeleteAsync(string basketId);
}