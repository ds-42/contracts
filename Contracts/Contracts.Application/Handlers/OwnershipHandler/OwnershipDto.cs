using Contracts.Domain;
using Contracts.Domain.Enums;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.OwnershipHandler;

public class OwnershipDto : IMapFrom<Ownership>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public FormType Type { get; set; }
}
