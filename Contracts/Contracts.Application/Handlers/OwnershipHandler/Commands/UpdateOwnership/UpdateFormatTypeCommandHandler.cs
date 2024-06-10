using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.OwnershipHandler.Commands.UpdateOwnership;

public class UpdateOwnershipCommandHandler(
    IBaseWriteRepository<Ownership> ownerships,
    ICurrentUserService user,
    OwnershipMemoryCache cache,
    IMapper _mapper) : IRequestHandler<UpdateOwnershipCommand, OwnershipDto>
{
    public async Task<OwnershipDto> Handle(UpdateOwnershipCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        var ownership = await ownerships.GetItem(command.Id, cancellationToken);

        _mapper.Map(command, ownership);

        await ownerships.UpdateAsync(ownership, cancellationToken);

        cache.Clear();

        return _mapper.Map<OwnershipDto>(ownership);
    }
}