namespace Contracts.Domain;

public class Contract
{
    public int Id { get; set; }
    public string Number { get; set; } = default!;
    public DateOnly RegistryDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public int FormatId { get; set; }
    public decimal PlannedPrice { get; set; }
    public int CurrencyId { get; set; }
    public string Description { get; set; } = default!;
    public int DocumentsGroup { get; set; }

    public Format Format { get; set; } = default!;
//    public IEnumerable<Document> Documents { get; set; } = default!;
    public Currency Currency { get; set; } = default!;
    public IEnumerable<ContractOrg> Orgs { get; set; } = default!;
}
