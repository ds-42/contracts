using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.ContractHandler;

public class ContractView : IMapTo<Contract>
{
    public string Number { get; set; } = default!;
    public DateTime RegistryDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public int FormatId { get; set; }
    public double PlannedPrice { get; set; }
    public int CurrencyId { get; set; }
    public string Description { get; set; } = default!;
}
