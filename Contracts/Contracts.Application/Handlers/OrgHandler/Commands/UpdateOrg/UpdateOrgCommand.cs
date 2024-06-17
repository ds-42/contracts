using Contracts.Domain;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.UpdateOrg;

public class UpdateOrgCommand : IMapTo<Org>, IRequest<OrgDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string ViewName { get; set; } = default!;
    public int? OwnershipId { get; set; }
    public int? MailAddressId { get; set; }
    public int? JureAddressId { get; set; }
}


