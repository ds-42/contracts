using Contracts.Application.Cashes;
using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.AddressHandler.Commands.UpdateAddress;

public class UpdateOrgAddressCommandHandler(
    AddressService addresses,
    СontractorService contractor,
    OrgMemoryCache cache) : IRequestHandler<UpdateOrgAddressCommand, AddressDto>
{
    public async Task<AddressDto> Handle(UpdateOrgAddressCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var org = await contractor.GetOrgAsync(cancellationToken);

        command.Group = org.AddressGroup;

        var addr = await addresses.UpdateAddressAsync(command, cancellationToken);

        cache.Clear();

        return addr;
    }
}