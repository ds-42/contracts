namespace Contracts.Domain;

public class Address
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public string Note { get; set; } = default!;

//    public IEnumerable<Org> Orgs { get; set; } = default!;
}
