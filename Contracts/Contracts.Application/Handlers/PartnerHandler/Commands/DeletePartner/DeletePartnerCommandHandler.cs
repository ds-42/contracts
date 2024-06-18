using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.PartnerHandler.Commands.DeletePartner;

public class DeletePartnerCommandHandler(
    IBaseWriteRepository<Partner> partners,
    ICurrentUserService user) : IRequestHandler<DeletePartnerCommand, bool>
{
    public async Task<bool> Handle(DeletePartnerCommand command, CancellationToken cancellationToken)
    {
        var partner = await partners.AsAsyncRead()
            .SingleAsync(t => t.OrgId == user.OrgId && t.PartnerId == command.Id, cancellationToken);

        await partners.RemoveAsync(partner, cancellationToken);

        return true;
    }
}