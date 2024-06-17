using Contracts.Application.Handlers.DocumentHandler.Commands.UpdateDocument;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.UpdateContractDoc;

public class UpdateContractDocCommand : UpdateDocumentCommand
{
    public int ContractId { get; set; }
}


