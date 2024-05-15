using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Commands.ContractAdd;

public class CreateContractCommand : IRequest<ContractDto>
{
    public int OrgId { get; set; }
    public string Number { get; set; } = default!;
    public DateTime RegistryDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public int FormatId { get; set; }
    public decimal PlannedPrice { get; set; }
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


