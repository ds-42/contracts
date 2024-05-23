namespace Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;

public class GetFormatsQueryValidator : FormatValidator<GetFormatsQuery>
{
    public GetFormatsQueryValidator()
    {
        RuleForId(t => t.OrgId);
        RuleForPagination(t => t);
    }
}
