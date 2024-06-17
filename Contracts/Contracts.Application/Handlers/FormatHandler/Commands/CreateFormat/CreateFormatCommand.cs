using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.CreateFormat;

public class CreateFormatCommand : IRequest<FormatDto>
{
    public string Name { get; set; } = default!;
    public int FormatTypeId { get; set; }

    public Format Map() => new()
    {
        Id = 0,
        Name = Name,
        FormatTypeId = FormatTypeId,
    };
}


