using Contracts.Domain;
using Contracts.Domain.Enums;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Commands.CreateContract;

public class CreateContractCommand : IRequest<ContractDto>
{
    public int PartnerId { get; set; }
    public string Number { get; set; } = default!;
    public DateOnly RegistryDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public int FormatId { get; set; }
    public decimal PlannedPrice { get; set; }
    public int CurrencyId { get; set; }
    public string Description { get; set; } = default!;
    public ContractRole Role { get; set; }
    public ContractState State { get; set; }

    public Contract Map() => new Contract()
    {
        Id = 0,
        OrgId = 0,
        PartnerId = PartnerId,
        Number = Number,
        RegistryDate = RegistryDate,
        StartDate = StartDate,
        FinishDate = FinishDate,
        FormatId = FormatId,
        PlannedPrice = PlannedPrice,
        CurrencyId = CurrencyId,
        Description = Description,
        Role = Role,
        State = State,
    };
}


