namespace Contracts.Domain;

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string Abbrev { get; set; } = default!;
}
