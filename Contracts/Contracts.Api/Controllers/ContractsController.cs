using Contracts.Application.Handlers.ContractHandler;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class ContractsController : AuthController
{
    public ContractsController(IMediator mediator) : base(mediator) 
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetContracts(
        [FromQuery] ContractsGetQuery getListQuery, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(getListQuery, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

}
