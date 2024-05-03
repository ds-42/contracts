using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    public AuthController(IMediator mediator) : base(mediator) { }
}
