using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.CreateFormat;

public class CreateFormatCommandHandler(
    IBaseWriteRepository<Format> formats,
    СontractorService contractor,
    FormatMemoryCache cache,
    IMapper _mapper) : IRequestHandler<CreateFormatCommand, FormatDto>
{
    public async Task<FormatDto> Handle(CreateFormatCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var format = command.Map();
        format.OrgId = contractor.OrgId;

        await formats.AddAsync(format, cancellationToken);

        cache.Clear();

        return _mapper.Map<FormatDto>(format);
    }
}