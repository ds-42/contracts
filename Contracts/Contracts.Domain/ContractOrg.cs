using Contracts.Domain.Enums;

namespace Contracts.Domain;

public class ContractOrg
{
    public int OrgId { get; set; }
    public int ContractId { get; set; }
    public ContractRole Role { get; set; }
    public ContractState State { get; set; }

    public Org Org { get; set; } = default!;
    public Contract Contract { get; set; } = default!;
}
