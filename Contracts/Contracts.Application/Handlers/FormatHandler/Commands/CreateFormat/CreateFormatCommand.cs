using Contracts.Domain;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.CreateFormat;

public class CreateFormatCommand : IRequest<FormatDto>, IMapTo<Format>
{
    public string Name { get; set; } = default!;
    public int FormatTypeId { get; set; }
}


