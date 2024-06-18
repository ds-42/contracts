using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.AppendOrgAdmin;

public class AppendOrgAdminCommand : IRequest<bool>
{
    public int UserId { get; set; }
}


