namespace Core.Application.DTOs;

public class CountableList<T> 
    where T : class, new()
{
    public IReadOnlyCollection<T> Items { get; init; } = default!;

    public int Count { get; init; }
}
