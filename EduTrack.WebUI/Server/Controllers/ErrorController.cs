using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
      /*  [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/api/error")]
        public IActionResult Get()
        {
            /*var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                EduTrackExceptionBase ex => ((int)ex.StatusCode, ex.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "Unxpected error occured.")
            };

            return Problem(title:message, statusCode: statusCode);
        }*/
    }
}
