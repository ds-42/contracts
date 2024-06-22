using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;


namespace Contracts.Application.Handlers.ContractHandler.Commands.CreateContract;

public class CreateContractCommandHandler(
    СontractorService contractor,
    IBaseWriteRepository<Contract> contracts,
    IBaseWriteRepository<Currency> currencies,
    IBaseWriteRepository<Format> formats,
    ContractCache cache,
    IMapper _mapper) : IRequestHandler<CreateContractCommand, ContractDto>
{
    public async Task<ContractDto> Handle(CreateContractCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        await currencies.TestExists(command.CurrencyId, cancellationToken);
        await formats.TestExists(contractor.OrgId, command.FormatId, cancellationToken);

        var contract = command.Map();
        contract.OrgId = contractor.OrgId;
        var rec = await contracts.AddAsync(contract, cancellationToken);

        cache.Clear();

        return _mapper.Map<ContractDto>(rec);
    }
}