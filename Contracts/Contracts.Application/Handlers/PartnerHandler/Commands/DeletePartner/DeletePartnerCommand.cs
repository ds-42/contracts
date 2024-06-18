using MediatR;

namespace Contracts.Application.Handlers.PartnerHandler.Commands.DeletePartner;

public class DeletePartnerCommand : IRequest<bool>
{
    public int Id { get; set; }
}


