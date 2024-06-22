using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OwnershipHandler.Commands.CreateOwnership;

public class CreateOwnershipCommandHandler(
    IBaseWriteRepository<Ownership> Ownerships,
    ICurrentUserService user,
    OwnershipCache cache,
    IMapper _mapper) : IRequestHandler<CreateOwnershipCommand, OwnershipDto>
{
    public async Task<OwnershipDto> Handle(CreateOwnershipCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        var ownership = await Ownerships.AddAsync(command.Map(), cancellationToken);

        cache.Clear();

        return _mapper.Map<OwnershipDto>(ownership);
    }
}