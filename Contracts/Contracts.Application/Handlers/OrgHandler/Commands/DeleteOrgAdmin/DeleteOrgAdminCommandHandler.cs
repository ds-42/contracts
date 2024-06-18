using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.DeleteOrgAdmin;

public class DeleteOrgAdminCommandHandler(
    IBaseWriteRepository<OrgAdmin> admins,
    ICurrentUserService user) : IRequestHandler<DeleteOrgAdminCommand, bool>
{
    public async Task<bool> Handle(DeleteOrgAdminCommand command, CancellationToken cancellationToken)
    {
        await admins.TestAccess(command.UserId, user.Id, cancellationToken);

        if (user.Id == command.UserId) 
        {   // нельзя удалить самого себя
            throw new AccessDeniedException();
        }

        var admin = await admins.AsAsyncRead()
            .SingleAsync(t => t.OrgId == user.OrgId && t.UserId == command.UserId, cancellationToken);

        await admins.RemoveAsync(admin, cancellationToken);

        return true;
    }
}