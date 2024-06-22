using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.DeleteFormatType;

public class DeleteFormatTypeCommandHandler(
    IBaseWriteRepository<Format> formats,
    IBaseWriteRepository<FormatType> formatTypes,
    ICurrentUserService user,
    FormatTypeCache cache) : IRequestHandler<DeleteFormatTypeCommand, bool>
{
    public async Task<bool> Handle(DeleteFormatTypeCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        if (await formats.UsedFormatType(command.Id, cancellationToken))
            throw new UsedAnotherTableException();

        var formatType = await formatTypes.GetItem(command.Id, cancellationToken);

        await formatTypes.RemoveAsync(formatType, cancellationToken);

        cache.Clear();

        return true;
    }
}