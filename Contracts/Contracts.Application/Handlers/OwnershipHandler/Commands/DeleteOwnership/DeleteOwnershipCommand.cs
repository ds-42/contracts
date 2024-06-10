using MediatR;

namespace Contracts.Application.Handlers.OwnershipHandler.Commands.DeleteOwnership;

public class DeleteOwnershipCommand : IRequest<bool>
{
    public int Id { get; set; }
}


