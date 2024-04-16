using Auth.Application.DTOs;
using Core.Auth.Application.Attributes;
using MediatR;

namespace Auth.Application.Handlers.Queries.GetCurrentUser;

[RequestAuthorize]
public class GetCurrentUserQuery : IRequest<GetUserDto>;