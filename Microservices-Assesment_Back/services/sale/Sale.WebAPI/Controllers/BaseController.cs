﻿using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Sale.WebAPI.Controllers;

public class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
