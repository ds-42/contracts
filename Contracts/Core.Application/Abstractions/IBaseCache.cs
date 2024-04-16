namespace Core.Application.Abstractions;

public interface IBaseCache<T>
{
    void Set(string key, T item, int size);
    bool TryGetValue(string key, out T? item);
    void DeleteItem(string key);
    void Clear();
}
