using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.DeleteOrgAdmin;

public class DeleteOrgAdminCommand : IRequest<bool>
{
    public int UserId { get; set; }
}


