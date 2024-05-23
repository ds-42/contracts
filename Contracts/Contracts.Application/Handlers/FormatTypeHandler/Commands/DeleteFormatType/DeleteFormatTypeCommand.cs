using MediatR;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.DeleteFormatType;

public class DeleteFormatTypeCommand : IRequest<bool>
{
    public int Id { get; set; }
}


