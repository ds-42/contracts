namespace Contracts.Domain;

public class File
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    public DateTime Date { get; set; }
}
