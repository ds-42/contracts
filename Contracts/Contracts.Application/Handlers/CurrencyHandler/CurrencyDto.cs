using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.ContractHandler;

public class CurrencyDto : IMapFrom<Currency>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string Abbrev { get; set; } = default!;
}
