using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Commands.DeleteContract;

public class DeleteContractCommand : IRequest<bool>
{
    public int Id { get; set; }
}


