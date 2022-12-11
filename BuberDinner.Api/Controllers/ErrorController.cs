﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            //Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem();
        }
    }
}
