using Contracts.Domain;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.CreateFormatType;

public class CreateFormatTypeCommand : IRequest<FormatTypeDto>, IMapTo<FormatType>
{
    public string Name { get; set; } = default!;
}


