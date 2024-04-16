using Common.Application.Controllers;
using Contracts.Application.Handlers.ContractHandler.Queries.GetContracts;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Users.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ContractsController : BaseController
{
    protected IBaseReadRepository<User> _source;

    public ContractsController(IBaseReadRepository<User> source, IMediator mediator) : base(mediator) 
    {
        _source = source;
    }

    [HttpGet]
    public async Task<IActionResult> GetContracts(
        [FromQuery] GetContractsQuery getListQuery, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(getListQuery, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

}
