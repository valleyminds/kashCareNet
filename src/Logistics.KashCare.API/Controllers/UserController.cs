
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace KashCareNet.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/health")]
[ApiVersion("1.0")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("KashCareNet API is running");
}
