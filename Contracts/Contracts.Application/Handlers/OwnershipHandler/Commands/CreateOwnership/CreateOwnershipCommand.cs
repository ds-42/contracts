using Contracts.Domain;
using Contracts.Domain.Enums;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.OwnershipHandler.Commands.CreateOwnership;

public class CreateOwnershipCommand : IRequest<OwnershipDto>, IMapTo<Ownership>
{
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public FormType Type { get; set; }
}


