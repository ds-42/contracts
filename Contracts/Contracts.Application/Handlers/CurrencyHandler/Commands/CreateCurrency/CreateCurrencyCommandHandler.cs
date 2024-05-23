using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.ContractHandler;
using Contracts.Application.Handlers.FormatHandler;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.CurrencyHandler.Commands.CreateCurrency;

public class CreateCurrencyCommandHandler(
    IBaseWriteRepository<Currency> currencies,
    ICurrentUserService user,
    CurrencyMemoryCache cache,
    IMapper _mapper) : IRequestHandler<CreateCurrencyCommand, CurrencyDto>
{
    public async Task<CurrencyDto> Handle(CreateCurrencyCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        await currencies.TestDuplicate(0, command.Abbrev, cancellationToken);

        var currency = await currencies.AddAsync(command.Map(), cancellationToken);

        cache.Clear();

        return _mapper.Map<CurrencyDto>(currency);
    }
}