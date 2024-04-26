using Core.Application.Abstractions;
using Core.Application.Extensions;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Policy;


namespace Core.Application.BaseRealizations;

public abstract class BaseCache<TItem> : IBaseCache<TItem>
{
    protected MemoryCache Cache = new(
        new MemoryCacheOptions
        {
            SizeLimit = 1024
        });

    protected virtual int AbsoluteExpiration => 10;

    protected virtual int SlidingExpiration => 5;

    public void Set(string key, TItem item, int size)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(AbsoluteExpiration))
            .SetSlidingExpiration(TimeSpan.FromMinutes(SlidingExpiration))
            .SetSize(size);
        Cache.Set(key, item, cacheEntryOptions);
    }

    public bool TryGetValue(string key, out TItem? item)
    {
        return Cache.TryGetValue(key, out item);
    }

    public void DeleteItem(string key)
    {
        Cache.Remove(key);
    }

    public void Clear()
    {
        Cache.Clear();
    }
}