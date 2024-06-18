using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.VerifyOrg;

public class VerifyOrgCommand : IRequest<bool>
{
    public int Id { get; set; }
    public bool State { get; set; }
}


