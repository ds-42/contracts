using Contracts.Application.Handlers.ContractHandler;
using Contracts.Application.Handlers.FormatHandler;
using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.CurrencyHandler.Commands.CreateCurrency;

public class CreateCurrencyCommand : IRequest<CurrencyDto>
{
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string Abbrev { get; set; } = default!;

    public Currency Map() => new()
    {
        Id = 0,
        Name = Name,
        ShortName = ShortName,
        Abbrev = Abbrev,
    };
}


