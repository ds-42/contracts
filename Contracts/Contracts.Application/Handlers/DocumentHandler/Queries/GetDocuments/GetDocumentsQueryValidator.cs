namespace Contracts.Application.Handlers.DocumentHandler.Queries.GetDocuments;

public class GetDocumentsQueryValidator : DocumentValidator<GetDocumentsQuery>
{
    public GetDocumentsQueryValidator()
    {
        RuleForId(t => t.Group);
        RuleForPagination(t => t);
    }
}
