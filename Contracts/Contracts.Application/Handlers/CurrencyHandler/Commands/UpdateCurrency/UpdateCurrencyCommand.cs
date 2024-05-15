using Contracts.Application.Handlers.ContractHandler;
using Contracts.Domain;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.CurrencyHandler.Commands.UpdateCurrency;

public class UpdateCurrencyCommand : IMapTo<Currency>, IRequest<CurrencyDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string Abbrev { get; set; } = default!;
}


