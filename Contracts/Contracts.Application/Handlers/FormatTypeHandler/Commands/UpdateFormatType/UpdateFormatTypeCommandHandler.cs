using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.FormatTypeHandler.Commands.UpdateFormatType;

public class UpdateFormatTypeCommandHandler(
    IBaseWriteRepository<FormatType> formatTypes,
    ICurrentUserService user,
    FormatTypeMemoryCache cache,
    IMapper _mapper) : IRequestHandler<UpdateFormatTypeCommand, FormatTypeDto>
{
    public async Task<FormatTypeDto> Handle(UpdateFormatTypeCommand command, CancellationToken cancellationToken)
    {
        user.TestAccess();

        var format = await formatTypes.GetItem(command.Id, cancellationToken);

        _mapper.Map(command, format);

        await formatTypes.UpdateAsync(format, cancellationToken);

        cache.Clear();

        return _mapper.Map<FormatTypeDto>(format);
    }
}