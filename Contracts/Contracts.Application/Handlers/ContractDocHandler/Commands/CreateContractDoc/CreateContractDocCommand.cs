using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Handlers.DocumentHandler.Commands.CreateDocument;
using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.CreateContractDoc;

public class CreateContractDocCommand : IRequest<DocumentDto>
{
    public int ContractId { get; set; }

    public CreateDocumentCommand Document { get; set; } = default!;
}


