using Core.Application.Abstractions;
using Core.Application.Extensions;
using System.Text.Json;


namespace Core.Application.BaseRealizations;

public abstract class BaseCache<TItem>(
    ICacheService cache) : IBaseCache<TItem> 
{
    private string ItemName => GetType().Name;
    protected string CreateKey(string key) => $"{ItemName}_{key}";

    public void Set(string key, TItem item, int size)
    {
        cache.Set(CreateKey(key), item.JsonSerialize());
    }

    public bool TryGetValue(string key, out TItem? item)
    {
        var itemString = cache.Get(CreateKey(key));
        if (String.IsNullOrEmpty(itemString))
        {
            item = default;
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
        cache.Remove(CreateKey(key));
    }

    public void Clear()
    {
        cache.RemoveKeys(ItemName + "*");
    }
}