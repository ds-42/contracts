using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.CreateFormatType;

public class CreateFormatTypeCommandHandler(
    IBaseWriteRepository<FormatType> formatTypes,
    ICurrentUserService user,
    FormatTypeCache cache,
    IMapper _mapper) : IRequestHandler<CreateFormatTypeCommand, FormatTypeDto>
{
    public async Task<FormatTypeDto> Handle(CreateFormatTypeCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        var formatType = _mapper.Map<FormatType>(command);

        await formatTypes.AddAsync(formatType, cancellationToken);

        cache.Clear();

        return _mapper.Map<FormatTypeDto>(formatType);
    }
}