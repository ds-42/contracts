using Contracts.Application.Handlers.DocumentHandler.Commands.CreateDocument;
using FluentValidation;

namespace Contracts.Application.Handlers.ContractDocHandler.Commands.CreateContractDoc;

public class CreateContractDocCommandValidator : AbstractValidator<CreateContractDocCommand>
{
    public CreateContractDocCommandValidator()
    {
        RuleFor(t => t.Document)
            .SetValidator(new CreateDocumentCommandValidator());

    }
}
