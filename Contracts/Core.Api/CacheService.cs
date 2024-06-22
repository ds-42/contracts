using Core.Application.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Core.Api;

public class CacheService(
    IDistributedCache distributedCache,
    IConfiguration config) : ICacheService
{
    protected virtual int AbsoluteExpiration => 10;
    protected virtual int SlidingExpiration => 5;

    string? ICacheService.Get(string key)
    {
        return distributedCache.GetString(key);
    }

    void ICacheService.Set(string key, string value)
    {
        distributedCache.SetString(key, value, new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(AbsoluteExpiration),
            SlidingExpiration = TimeSpan.FromMinutes(SlidingExpiration),
        });
    }

    void ICacheService.Remove(string key)
    {
        distributedCache.Remove(key);
    }

    void ICacheService.RemoveKeys(string pattern)
    {
        var redis_cs = config.GetConnectionString("Redis")!;
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redis_cs);
        IDatabase db = redis.GetDatabase();

        var keys = redis.GetServer(redis_cs).Keys(pattern: pattern);

        foreach (var key in keys)
        {
            distributedCache.Remove(key!);
        }
    }
}
