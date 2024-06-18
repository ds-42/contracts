using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Core.Api.Controllers;

//[Authorize]
public class AuthController : BaseController
{
    public AuthController(IMediator mediator) : base(mediator) { }
}
