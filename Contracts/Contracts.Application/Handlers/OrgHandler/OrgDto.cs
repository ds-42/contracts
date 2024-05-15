using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.OrgHandler;

public class OrgDto : IMapFrom<Org>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string ViewName { get; set; } = default!;
}
