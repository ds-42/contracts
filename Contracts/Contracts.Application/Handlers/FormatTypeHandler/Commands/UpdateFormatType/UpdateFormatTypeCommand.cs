using Contracts.Domain;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.UpdateFormatType;

public class UpdateFormatTypeCommand : IMapTo<FormatType>, IRequest<FormatTypeDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}


