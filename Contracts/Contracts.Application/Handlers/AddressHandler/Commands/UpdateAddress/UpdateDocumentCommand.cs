using Contracts.Domain;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.AddressHandler.Commands.UpdateAddress;

public class UpdateAddressCommand : IMapTo<Address>, IRequest<AddressDto>
{
    public int Id { get; set; }
    public int Group { get; set; }
    public string Note { get; set; } = default!;
}


