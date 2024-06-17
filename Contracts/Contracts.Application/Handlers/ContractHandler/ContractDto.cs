using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.ContractHandler;

public class ContractDto : IMapFrom<Contract>
{
    public int Id { get; set; }
    public string Number { get; set; } = default!;
    public DateOnly RegistryDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public int FormatId { get; set; }
    public double PlannedPrice { get; set; }
    public int CurrencyId { get; set; }
    public string Description { get; set; } = default!;
}

public class ContractExDto : ContractDto 
{
    public string FormatName { get; set; } = default!;
    public string CurrencyName { get; set; } = default!;
    public string CurrencyShortName { get; set; } = default!;
}
