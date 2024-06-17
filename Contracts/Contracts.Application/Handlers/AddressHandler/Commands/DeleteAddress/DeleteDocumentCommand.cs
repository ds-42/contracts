using MediatR;

namespace Contracts.Application.Handlers.AddressHandler.Commands.DeleteAddress;

public class DeleteAddressCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int Group { get; set; }
}


