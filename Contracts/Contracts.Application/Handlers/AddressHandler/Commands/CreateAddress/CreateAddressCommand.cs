using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.AddressHandler.Commands.CreateAddress;

public class CreateAddressCommand : IRequest<AddressDto>
{
    public int Group { get; set; }
    public string Note { get; set; } = default!;

    public Address Map() => new()
    {
        Id = 0,
        GroupId = Group,
        Note = Note,
    };
}


