using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Commands.CreateContract;

public class CreateContractCommand : IRequest<ContractDto>
{
    public string Number { get; set; } = default!;
    public DateOnly RegistryDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
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


