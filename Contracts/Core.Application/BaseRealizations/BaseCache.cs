using Core.Application.Abstractions;
using Core.Application.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;


namespace Core.Application.BaseRealizations;

public abstract class BaseCache<TItem>(
    IDistributedCache distributedCache,
    IServer redisServer) : IBaseCache<TItem> where TItem : class
{
    protected virtual int AbsoluteExpiration => 10;

    protected virtual int SlidingExpiration => 5;

    public void Set(string key, TItem item, int size)
    {
        distributedCache.SetString(key, item.JsonSerialize(), new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = new DateTimeOffset(0, 0, 0, 0, 0, 0, TimeSpan.FromMinutes(AbsoluteExpiration)),
            SlidingExpiration = TimeSpan.FromMinutes(SlidingExpiration),
        });
    }

    public bool TryGetValue(string key, out TItem? item)
    {
        var itemString = distributedCache.GetString(key);
        if (String.IsNullOrEmpty(itemString))
        {
            item = null;
            return false;
        }
        item = JsonSerializer.Deserialize<TItem>(itemString, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = false,
        });
        return true;
    }

    public void DeleteItem(string key)
    {
        distributedCache.Remove(key);
    }

    public void Clear()
    {
        redisServer.FlushAllDatabasesAsync();
    }
}