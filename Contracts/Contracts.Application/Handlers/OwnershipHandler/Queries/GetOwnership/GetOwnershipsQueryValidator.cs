using Contracts.Application.Handlers.FormatTypeHandler;
using Contracts.Application.Handlers.OwnershipHandler.Queries.GetOwnership;

namespace Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;

public class GetOwnershipsQueryValidator : FormatTypeValidator<GetOwnershipsQuery>
{
    public GetOwnershipsQueryValidator()
    {
        RuleForPagination(t => t);
    }
}
