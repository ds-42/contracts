using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.CreateFormat;

public class CreateFormatCommandHandler(
    IBaseWriteRepository<Format> formats,
    IBaseWriteRepository<Employee> employees,
    ICurrentUserService user,
    FormatMemoryCache cache,
    IMapper _mapper) : IRequestHandler<CreateFormatCommand, FormatDto>
{
    public async Task<FormatDto> Handle(CreateFormatCommand command, CancellationToken cancellationToken)
    {
        await employees.TestAccess(command.OrgId, user.Id, cancellationToken);

        var format = await formats.AddAsync(command.Map(), cancellationToken);

        cache.Clear();

        return _mapper.Map<FormatDto>(format);
    }
}