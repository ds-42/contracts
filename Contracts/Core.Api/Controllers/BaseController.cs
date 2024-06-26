﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text;
using System;

namespace Core.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    public readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected void SetTotalCountHeader(int value)
    {
        HttpContext.Response.Headers
            .Append("X-Total-Count", value.ToString());
    }

    protected async Task<T> ExecCommandAsync<T>(IRequest<T> command, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    protected async Task<T> ExecQueryAsync<T>(IRequest<T> query, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(query, cancellationToken);
    }
}
