using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.FormatTypeHandler;

public class FormatTypeDto : IMapFrom<FormatType>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
