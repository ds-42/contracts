using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.ContractDocHandler.Commands.DeleteContractDoc;
using Contracts.Application.Handlers.DocumentHandler.Commands.DeleteDocument;
using Contracts.Application.Handlers.FormatHandler.Commands.DeleteFormat;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
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