using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.UpdateFormat;

public class UpdateFormatCommandHandler(
    IBaseWriteRepository<Format> formats,
    IBaseWriteRepository<Employee> employees,
    ICurrentUserService user,
    FormatCache cache,
    IMapper _mapper) : IRequestHandler<UpdateFormatCommand, FormatDto>
{
    public async Task<FormatDto> Handle(UpdateFormatCommand command, CancellationToken cancellationToken)
    {
        await employees.TestAccess(user.OrgId, user.Id, cancellationToken);

        var format = await formats.GetItem(user.OrgId, command.Id, cancellationToken);

        _mapper.Map(command, format);

        await formats.UpdateAsync(format, cancellationToken);

        cache.Clear();

        return _mapper.Map<FormatDto>(format);
    }
}