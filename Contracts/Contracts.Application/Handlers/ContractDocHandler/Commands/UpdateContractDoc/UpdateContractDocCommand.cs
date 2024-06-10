using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Handlers.DocumentHandler.Commands.UpdateDocument;
using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.UpdateContractDoc;

public class UpdateContractDocCommand : IRequest<DocumentDto>
{
    public int ContractId { get; set; }
    public UpdateDocumentCommand Document { get; set; } = default!;
}


