namespace Contracts.Domain;

public class Address
{
    public int Id { get; set; }
    public int Group { get; set; }
    public string Note { get; set; } = default!;
}
