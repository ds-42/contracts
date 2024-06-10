using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.DeleteContractDoc;

public class DeleteContractDocCommand : IRequest<bool>
{
    public int Id { get; set; }
}


