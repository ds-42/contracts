using Contracts.Application.Handlers.OrgAddressHandler.Queries.GetOrgAddresses;

namespace Contracts.Application.Handlers.AddressHandler.Queries.GetAddresses;

public class GetOrgAddressesQueryValidator : AddressValidator<GetOrgAddressesQuery>
{
    public GetOrgAddressesQueryValidator()
    {
        RuleForPagination(t => t);
    }
}
