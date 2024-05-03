using Auth.Application.DTOs;
using AutoMapper;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using Core.Users.Domain;
using MediatR;

namespace Auth.Application.Handlers.Queries.GetCurrentUser;

internal class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, GetUserDto>
{
    private readonly IBaseReadRepository<User> _users;
    
    private readonly ICurrentUserService _currentUserService;
    
    private readonly IMapper _mapper;

    public GetCurrentUserQueryHandler(
        IBaseReadRepository<User> users, 
        ICurrentUserService currentUserService,
        IMapper mapper)
    {
        _users = users;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }
    
    public async Task<GetUserDto> Handle(GetCurrentUserQuery request,  CancellationToken cancellationToken)
    {
        var user = await _users.AsAsyncRead()
            .SingleOrDefaultAsync(e => e.Id == _currentUserService.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException($"User with id {_currentUserService.Id}");
        }

        return _mapper.Map<GetUserDto>(user);
    }
}