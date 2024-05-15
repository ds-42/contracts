using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.ContractHandler;
using Contracts.Application.Handlers.CurrencyHandler.Commands.UpdateCurrency;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.CurrencyHandler.Commands.CreateCurrency;

public class UpdateCurrencyCommandHandler(
    IBaseWriteRepository<Currency> currencies,
    ICurrentUserService user,
    CurrencyMemoryCache cache,
    IMapper _mapper) : IRequestHandler<UpdateCurrencyCommand, CurrencyDto>
{
    public async Task<CurrencyDto> Handle(UpdateCurrencyCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        await currencies.TestDuplicate(command.Id, command.Abbrev, cancellationToken);
        
        var currency = await currencies.GetItem(command.Id, cancellationToken);

        _mapper.Map(command, currency);

        await currencies.UpdateAsync(currency, cancellationToken);

        cache.Clear();

        return _mapper.Map<CurrencyDto>(currency);
    }
}