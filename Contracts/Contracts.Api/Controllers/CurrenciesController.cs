using Contracts.Application.Handlers.CurrencyHandler.Commands.CreateCurrency;
using Contracts.Application.Handlers.CurrencyHandler.Commands.DeleteCurrency;
using Contracts.Application.Handlers.CurrencyHandler.Commands.UpdateCurrency;
using Contracts.Application.Handlers.CurrencyHandler.Queries.GetCurrencies;
using Core.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Api.Controllers;

public class CurrenciesController : AuthController
{
    public CurrenciesController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetCurrencies(
        [FromQuery] GetCurrenciesQuery query, CancellationToken cancellationToken = default)
    {
        var data = await ExecQueryAsync(query, cancellationToken);

        SetTotalCountHeader(data.Count);
        return Ok(data.Items);
    }

    [HttpPost]
    public async Task<IActionResult> AppendCurrency(
        CreateCurrencyCommand command,
        CancellationToken cancellationToken = default)
    {
        var currency = await ExecQueryAsync(command, cancellationToken);

        return Created($"Currencies/{currency.Id}", currency);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCurrency(
        int id,
        UpdateCurrencyCommand command,
        CancellationToken cancellationToken = default)
    {
        command.Id = id;
        var currency = await ExecQueryAsync(command, cancellationToken);

        return Ok(currency);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCurrency(
        int id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteCurrencyCommand() { Id = id };
        await ExecQueryAsync(command, cancellationToken);

        return Ok();
    }
}

