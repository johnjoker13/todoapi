using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/")]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {

        return Ok();
    }
}