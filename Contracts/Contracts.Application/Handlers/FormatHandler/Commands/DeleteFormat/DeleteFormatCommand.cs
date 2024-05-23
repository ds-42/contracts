using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.DeleteFormat;

public class DeleteFormatCommand : IRequest<bool>
{
    public int Id { get; set; }
}


