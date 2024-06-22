using Contracts.Application.Cashes;
using Contracts.Application.Handlers.AddressHandler;
using Contracts.Application.Handlers.AddressHandler.Commands.CreateAddress;
using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.OrgAddressHandler.Commands.CreateOrgAddress;

public class CreateOrgAddressCommandHandler(
    AddressService addresses,
    СontractorService contractor,
    OrgCache cache) : IRequestHandler<CreateOrgAddressCommand, AddressDto>
{
    public async Task<AddressDto> Handle(CreateOrgAddressCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var org = await contractor.GetOrgAsync(cancellationToken);

        command.Group = org.AddressGroup;

        var addr = await addresses.CreateAddressAsync(command, cancellationToken);

        if (org.AddressGroup == 0)
        {
            org.AddressGroup = command.Group;

            await contractor.SaveOrgAsync(org, cancellationToken);

            cache.Clear();
        }

        return addr;
    }
}