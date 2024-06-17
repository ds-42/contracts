namespace Contracts.Application.Handlers.AddressHandler.Commands.UpdateAddress;

public class UpdateAddressCommandValidator : AddressValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleForId(t => t.Id);
        RuleForNote(t => t.Note);
    }
}
