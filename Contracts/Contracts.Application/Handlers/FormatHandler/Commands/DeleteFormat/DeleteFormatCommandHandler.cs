using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.DeleteFormat;

public class DeleteFormatCommandHandler(
    IBaseWriteRepository<Format> formats,
    IBaseWriteRepository<Employee> employees,
    ICurrentUserService user,
    FormatMemoryCache cache) : IRequestHandler<DeleteFormatCommand, bool>
{
    public async Task<bool> Handle(DeleteFormatCommand command, CancellationToken cancellationToken)
    {
        var format = await formats.GetItem(command.Id, cancellationToken);

        await employees.TestAccess(format.OrgId, user.Id, cancellationToken);

        await formats.RemoveAsync(format, cancellationToken);

        cache.Clear();

        return true;
    }
}