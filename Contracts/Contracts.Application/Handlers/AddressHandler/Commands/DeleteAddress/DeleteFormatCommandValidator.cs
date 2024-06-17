namespace Contracts.Application.Handlers.AddressHandler.Commands.DeleteAddress;

public class DeleteAddressCommandValidator : AddressValidator<DeleteAddressCommand>
{
    public DeleteAddressCommandValidator()
    {
        RuleForId(t => t.Id);
    }
}
