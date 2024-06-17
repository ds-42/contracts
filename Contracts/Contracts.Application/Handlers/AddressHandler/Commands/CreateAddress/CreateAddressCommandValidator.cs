namespace Contracts.Application.Handlers.AddressHandler.Commands.CreateAddress;

public class CreateAddressCommandValidator : AddressValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleForNote(t => t.Note);
    }
}
