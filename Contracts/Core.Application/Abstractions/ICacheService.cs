namespace Core.Application.Abstractions;

public interface ICacheService
{
    void Set(string key, string value);
    string? Get(string key);
    void Remove(string key);
    void RemoveKeys(string pattern);
}
