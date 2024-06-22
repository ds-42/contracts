using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.CurrencyHandler.Commands.DeleteCurrency;

public class DeleteCurrencyCommandHandler(
    IBaseWriteRepository<Currency> currencies,
    ICurrentUserService user,
    CurrencyCache cache) : IRequestHandler<DeleteCurrencyCommand, bool>
{
    public async Task<bool> Handle(DeleteCurrencyCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        var currency = await currencies.GetItem(command.Id, cancellationToken);

        await currencies.RemoveAsync(currency, cancellationToken);

        cache.Clear();

        return true;
    }
}