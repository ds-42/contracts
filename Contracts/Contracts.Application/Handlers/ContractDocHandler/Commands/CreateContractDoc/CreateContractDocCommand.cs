using Contracts.Application.Handlers.DocumentHandler.Commands.CreateDocument;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.CreateContractDoc;

public class CreateContractDocCommand : CreateDocumentCommand
{
    public int ContractId { get; set; }
}


