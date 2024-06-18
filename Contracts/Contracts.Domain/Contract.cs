using Contracts.Domain.Enums;

namespace Contracts.Domain;

public class Contract
{
    public int Id { get; set; }
    public int OrgId { get; set; }
    public Org Org { get; set; } = default!;
    public int PartnerId { get; set; }
    public Org Partner { get; set; } = default!;
    public string Number { get; set; } = default!;
    public DateOnly RegistryDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public int FormatId { get; set; }
    public Format Format { get; set; } = default!;
    public decimal PlannedPrice { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int DocumentsGroup { get; set; }

//    public IEnumerable<Document> Documents { get; set; } = default!;
    public ContractRole Role { get; set; }
    public ContractState State { get; set; }
}
