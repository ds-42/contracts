using Contracts.Application.Handlers.ContractHandler;
using Contracts.Domain;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.CurrencyHandler.Commands.DeleteCurrency;

public class DeleteCurrencyCommand : IRequest<bool>
{
    public int Id { get; set; }
}


