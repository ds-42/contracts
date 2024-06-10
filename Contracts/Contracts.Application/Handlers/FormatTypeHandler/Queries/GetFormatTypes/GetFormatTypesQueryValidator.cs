using Contracts.Application.Handlers.FormatTypeHandler;
using Contracts.Application.Handlers.FormatTypeHandler.Queries.GetFormatTypes;
using Contracts.Application.Handlers.OwnershipHandler.Queries.GetOwnership;

namespace Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;

public class GetFormatTypesQueryValidator : FormatTypeValidator<GetFormatTypesQuery>
{
    public GetFormatTypesQueryValidator()
    {
        RuleForPagination(t => t);
    }
}
