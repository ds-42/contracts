using Contracts.Domain;
using Contracts.Domain.Enums;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Commands.UpdateContract;

public class UpdateContractCommand : IMapTo<Contract>, IRequest<ContractDto>
{
    public int Id { get; set; }
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
}


