using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.Extensions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Application.Handlers.Quaries;

public abstract class CachedQueryHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    private readonly IBaseCache<TResult> _cache;

    public CachedQueryHandler(IBaseCache<TResult> cache)
    {
        _cache = cache;
    }

    protected virtual string GetCacheKey(TRequest query)
    {
        return $"{nameof(query)}:{query.JsonSerialize()}";
//        return $"{query.GetType().Name}:{query.JsonSerialize()}";
    }

    public async Task<TResult> Handle(TRequest query, CancellationToken cancellationToken)
    {
        var cacheKey = GetCacheKey(query);

        if (_cache.TryGetValue(cacheKey, out TResult? result))
        {
            return result!;
        }

        result = await ExecQuery(query, cancellationToken);

/*        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(10))
            .SetSlidingExpiration(TimeSpan.FromSeconds(5))
            .SetSize(_cacheSize);*/

        _cache.Set(cacheKey, result, 1);

        return result;
    }

    protected abstract Task<TResult> ExecQuery(TRequest query, CancellationToken cancellationToken);

}
