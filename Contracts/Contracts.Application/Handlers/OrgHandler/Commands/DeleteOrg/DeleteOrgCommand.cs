using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.DeleteOrg;

public class DeleteOrgCommand : IRequest<bool>
{
    public int Id { get; set; }
}


