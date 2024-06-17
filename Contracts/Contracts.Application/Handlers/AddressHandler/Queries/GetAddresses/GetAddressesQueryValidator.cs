namespace Contracts.Application.Handlers.AddressHandler.Queries.GetAddresses;

public class GetAddressesQueryValidator : AddressValidator<GetAddressesQuery>
{
    public GetAddressesQueryValidator()
    {
        RuleForId(t => t.Group);
        RuleForPagination(t => t);
    }
}
