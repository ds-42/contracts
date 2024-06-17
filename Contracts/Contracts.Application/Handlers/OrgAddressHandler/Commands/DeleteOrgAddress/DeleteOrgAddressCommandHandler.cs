using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.OrgAddressHandler.Commands.DeleteOrgAddress;

public class DeleteOrgAddressCommandHandler(
    СontractorService contractor,
    AddressService addresses) : IRequestHandler<DeleteOrgAddressCommand, bool>
{
    public async Task<bool> Handle(DeleteOrgAddressCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        // Валидация договора 
        var org = await contractor.GetOrgAsync(cancellationToken);
        command.Group = org.AddressGroup;

        return await addresses.DeleteAddressAsync(command, cancellationToken);
    }
}