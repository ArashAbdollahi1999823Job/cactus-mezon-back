using System.Text;
using Application.Helpers;
using Application.IContracts.IBehaviourPipe;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
namespace Application.Common.BehavioursPipe;
public class BehavioursCacheQuery<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBehavioursCacheQuery, IRequest<TResponse>
{
    #region CtorAndInjections
    private readonly IDistributedCache _cache; // save data cache
    private readonly IHttpContextAccessor _httpContextAccessor; //access to request
    public BehavioursCacheQuery(IDistributedCache cache, IHttpContextAccessor httpContextAccessor)
    {
        _cache = cache;
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion

    #region HandleRequest
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request.MinutesCache == 0)
        {
           return await next();
        }
        else
        {
            TResponse response;
            var key = GenerateKey();
            var cachedResponse = await _cache.GetAsync(key, cancellationToken);
            if (cachedResponse != null)
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
            else
            {
                response = await next(); // go to get response
                var serialized = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
                await CreateNewCache(request, key, cancellationToken, serialized);
            }
            return response;
        }
    }
    #endregion

    #region CreateNewCache
    private Task CreateNewCache(TRequest request, string key, CancellationToken cancellationToken, byte[] serialized)
    {
        return _cache.SetAsync(key, serialized,
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeToLive(request)
            },
            cancellationToken);
    }
    #endregion

    #region TimeToLiveCache
    private static TimeSpan TimeToLive(TRequest request)
    {
        return new TimeSpan(0, 0, request.MinutesCache, 0);
    }
    #endregion

    #region GenerateKey
    private string GenerateKey()
    {
        return IdGenerator.GenerateCacheKeyFromRequest(_httpContextAccessor.HttpContext.Request);
    } 
    #endregion
}