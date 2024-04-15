using Common.Application.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ContractsController : BaseController
{
    public ContractsController(IMediator mediator) : base(mediator) 
    {
    }

/*    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] GetListQuery getListQuery, CancellationToken cancellationToken = default)
    {
        var getCountQuery = new GetCountQuery() { OwnerId = getListQuery.OwnerId, Predicate = getListQuery.Predicate };

        var items = await ExecQueryAsync(getListQuery, cancellationToken);
        int count = await ExecQueryAsync(getCountQuery, cancellationToken);
        HttpContext.Response.Headers
            .Append("X-Total-Count", count.ToString());

        return Ok(items);
    }*/

}
