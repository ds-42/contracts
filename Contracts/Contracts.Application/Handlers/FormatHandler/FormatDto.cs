using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.FormatHandler;

public class FormatDto : IMapFrom<Format>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int FormatTypeId { get; set; }
}

public class FormatExDto : FormatDto
{
    public string FormatType { get; set; } = default!;
}
