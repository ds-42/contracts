using Contracts.Application.Handlers.FormatTypeHandler;
using Contracts.Application.Handlers.FormatTypeHandler.Queries.GetFormatTypes;

namespace Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;

public class GetFormatTypesQueryValidator : FormatTypeValidator<GetFormatTypesQuery>
{
    public GetFormatTypesQueryValidator()
    {
        RuleForPagination(t => t);
    }
}
