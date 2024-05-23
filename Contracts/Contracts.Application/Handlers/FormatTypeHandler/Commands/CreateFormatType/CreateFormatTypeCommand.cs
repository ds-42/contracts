using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.CreateFormatType;

public class CreateFormatTypeCommand : IRequest<FormatTypeDto>
{
    public string Name { get; set; } = default!;

    public FormatType Map() => new()
    {
        Id = 0,
        Name = Name,
    };
}


