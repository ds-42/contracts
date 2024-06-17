using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.OrgHandler;

public class OrgDto : IMapFrom<Org>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string ViewName { get; set; } = default!;
    public int OwnershipId { get; set; } = default!;
    public string UNP { get; set; } = default!;
    public string OKPO { get; set; } = default!;
}

public class OrgExDto : OrgDto 
{
    public string FullName { get; set; } = default!;
    public string Ownership { get; set; } = default!;
}
