namespace Contracts.Domain;

public class Partner
{
    public int Id { get; set; }
    public int OrgId { get; set; }
    public Org Org { get; set; } = default!;
    public int PartnerId { get; set; }
    public Org PartnerOrg { get; set; } = default!;
    public string ViewName { get; set; } = default!;
}
