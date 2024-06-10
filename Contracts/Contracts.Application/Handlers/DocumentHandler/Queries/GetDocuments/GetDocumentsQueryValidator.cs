using Contracts.Application.Handlers.FormatHandler;
using Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;

namespace Contracts.Application.Handlers.DocumentHandler.Queries.GetDocuments;

public class GetDocumentsQueryValidator : FormatValidator<GetDocumentsQuery>
{
    public GetDocumentsQueryValidator()
    {
        RuleForId(t => t.GroupId);
        RuleForPagination(t => t);
    }
}
