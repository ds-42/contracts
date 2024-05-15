using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;


namespace Contracts.Application.Handlers.ContractHandler.Commands.ContractAdd;

public class CreateContractCommandHandler(
    IBaseWriteRepository<Contract> contracts,
    IBaseWriteRepository<Employee> employes,
    IBaseWriteRepository<ContractOrg> orgs,
    ICurrentUserService user,
    ContractMemoryCache cache,
    IMapper _mapper) : IRequestHandler<CreateContractCommand, ContractDto>
{
    public async Task<ContractDto> Handle(CreateContractCommand command, CancellationToken cancellationToken)
    {
        await employes.TestAccess(command.OrgId, user.Id, cancellationToken);

        var rec = await contracts.AddAsync(command.Map(), cancellationToken);

        await orgs.AddAsync(new ContractOrg()
        {
            ContractId = rec.Id,
            OrgId = rec.Id,
        }, cancellationToken);

        cache.Clear();

        return _mapper.Map<ContractDto>(rec);
    }
}