using Application.IContracts.IRepository;
using Domain.Entities.BasketEntity;
using StackExchange.Redis;
using JsonSerializer = System.Text.Json.JsonSerializer;
namespace Infrastructure.Persistence.Contract.Repository;
public class BasketRepository:IBasketRepository
{
    #region CtorAndInjection
    private readonly IDatabase _redisDatabase;
    private RedisValue basket;
    public BasketRepository(IConnectionMultiplexer redisDatabase)
    {
        _redisDatabase = redisDatabase.GetDatabase();
    }
    #endregion

    #region BasketGetAsync
    public async  Task<Basket> BasketGetAsync(string id)
    {
        basket = await _redisDatabase.StringGetAsync(id);
        return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(basket);
    }
    #endregion
    
    #region BasketEditAsync
    public async Task<Basket> BasketEditAsync(Basket basket)
    {
        var newBasket = await _redisDatabase.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket),TimeSpan.FromDays(2));
        if (!newBasket) return null;
        return await BasketGetAsync(basket.Id);
    }
    #endregion
    
    #region BasketDeleteAsync
    public async Task<bool> BasketDeleteAsync(string id)
    {
        return  await _redisDatabase.KeyDeleteAsync(id);
    }
    #endregion
}