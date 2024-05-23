using Contracts.Domain;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.UpdateFormat;

public class UpdateFormatCommand : IMapTo<Format>, IRequest<FormatDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int FormatTypeId { get; set; }
}


