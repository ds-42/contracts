using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.CreateFormat;

public class CreateFormatCommand : IRequest<FormatDto>
{
    public int OrgId { get; set; }
    public string Name { get; set; } = default!;
    public int FormatTypeId { get; set; }

    public Format Map() => new()
    {
        Id = 0,
        OrgId = OrgId,
        Name = Name,
        FormatTypeId = FormatTypeId,
    };
}


