using MediatR;

namespace Contracts.Application.Handlers.CurrencyHandler.Commands.DeleteCurrency;

public class DeleteCurrencyCommand : IRequest<bool>
{
    public int Id { get; set; }
}


