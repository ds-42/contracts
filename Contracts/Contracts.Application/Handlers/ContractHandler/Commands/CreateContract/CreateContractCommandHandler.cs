using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;


namespace Contracts.Application.Handlers.ContractHandler.Commands.CreateContract;

public class CreateContractCommandHandler(
    IBaseWriteRepository<Contract> contracts,
    IBaseWriteRepository<Currency> currencies,
    IBaseWriteRepository<Employee> employes,
    IBaseWriteRepository<Format> formats,
    IBaseWriteRepository<ContractOrg> orgs,
    ICurrentUserService user,
    ContractMemoryCache cache,
    IMapper _mapper) : IRequestHandler<CreateContractCommand, ContractDto>
{
    public async Task<ContractDto> Handle(CreateContractCommand command, CancellationToken cancellationToken)
    {
        await employes.TestAccess(command.OrgId, user.Id, cancellationToken);

        await currencies.TestExists(command.CurrencyId, cancellationToken);
        await formats.TestExists(command.FormatId, cancellationToken);

        var rec = await contracts.AddAsync(command.Map(), cancellationToken);

        await orgs.AddAsync(new ContractOrg()
        {
            ContractId = rec.Id,
            OrgId = command.OrgId,
            Role = Domain.Enums.ContractRole.Default,
            State = Domain.Enums.ContractState.Default,
        }, cancellationToken);

        cache.Clear();

        return _mapper.Map<ContractDto>(rec);
    }
}