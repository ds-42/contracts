using Contracts.Domain;
using Contracts.Domain.Enums;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.OwnershipHandler.Commands.UpdateOwnership;

public class UpdateOwnershipCommand : IMapTo<Ownership>, IRequest<OwnershipDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public FormType Type { get; set; }
}


