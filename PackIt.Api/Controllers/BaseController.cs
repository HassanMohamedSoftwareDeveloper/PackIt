using Microsoft.AspNetCore.Mvc;

namespace PackIt.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
     => result is null ? NotFound() : Ok(result);
}
