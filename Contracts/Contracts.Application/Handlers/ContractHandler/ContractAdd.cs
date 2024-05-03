using AutoMapper;
using Contracts.Application.Extensions;
using Contracts.Application.Cashes;
using Contracts.Application.Handlers.EmployeeHandler;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler;

public class ContractAddCommand : IRequest<ContractView>
{
    public int OrgId { get; set; }
    public string Number { get; set; } = default!;
    public DateTime RegistryDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public int FormatId { get; set; }
    public double PlannedPrice { get; set; }
    public int CurrencyId { get; set; }
    public string Description { get; set; } = default!;

    public Contract Map() => new Contract()
    {
        Id = 0,
        Number = Number,
        RegistryDate = RegistryDate,
        StartDate = StartDate,
        FinishDate = FinishDate,
        FormatId = FormatId,
        PlannedPrice = PlannedPrice,
        CurrencyId = CurrencyId,
        Description = Description,
    };
}

public class ContractAddHandler(
    IBaseWriteRepository<Contract> contracts,
    IBaseWriteRepository<Employee> employes,
    IBaseWriteRepository<ContractOrg> orgs,
    ICurrentUserService user,
    ContractMemoryCache cache,
    IMapper _mapper) : IRequestHandler<ContractAddCommand, ContractView>
{
    public async Task<ContractView> Handle(ContractAddCommand command, CancellationToken cancellationToken)
    {
        await employes.GetItem(command.OrgId, user.Id, cancellationToken);

        var rec = await contracts.AddAsync(command.Map(), cancellationToken);

        await orgs.AddAsync(new ContractOrg()
        {
            ContractId = rec.Id,
            OrgId = rec.Id,
        }, cancellationToken);

        cache.Clear();

        return _mapper.Map<ContractView>(rec);
    }
}

public class ContractAddValidator : ContractValidator<ContractAddCommand>
{
    public ContractAddValidator()
    {
    }
}

