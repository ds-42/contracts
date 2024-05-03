using Core.Application.Abstractions;
using Core.Application.Extensions;
using MediatR;

namespace Core.Application.BaseHandlers;

public abstract class BaseCachedQuery<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    private readonly IBaseCache<TResult> _cache;

    public BaseCachedQuery(IBaseCache<TResult> cache)
    {
        _cache = cache;
    }

    protected virtual string GetCacheKey(TRequest query)
    {
        return $"{nameof(query)}:{query.JsonSerialize()}";
    }

    protected virtual async Task TestDataAccessAsync(TRequest query, CancellationToken cancellationToken) 
    {
        await Task.CompletedTask;
    }

    public async Task<TResult> Handle(TRequest query, CancellationToken cancellationToken)
    {
        await TestDataAccessAsync(query, cancellationToken);

        var cacheKey = GetCacheKey(query);

        if (_cache.TryGetValue(cacheKey, out TResult? result))
        {
            return result!;
        }

        result = await ExecQuery(query, cancellationToken);

        _cache.Set(cacheKey, result, 1);

        return result;
    }

    protected abstract Task<TResult> ExecQuery(TRequest query, CancellationToken cancellationToken);

}
