namespace Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;

public class GetFormatsQueryValidator : FormatValidator<GetFormatsQuery>
{
    public GetFormatsQueryValidator()
    {
        RuleForPagination(t => t);
    }
}
