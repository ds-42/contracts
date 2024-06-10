using Contracts.Domain;
using Contracts.Domain.Enums;
using MediatR;

namespace Contracts.Application.Handlers.OwnershipHandler.Commands.CreateOwnership;

public class CreateOwnershipCommand : IRequest<OwnershipDto>
{
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public FormType Type { get; set; }

    public Ownership Map() => new()
    {
        Id = 0,
        Name = Name,
        ShortName = ShortName,
    };
}


