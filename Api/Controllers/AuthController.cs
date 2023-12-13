using System.Net;
using Application.Commands;
using Contracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {

        var command = _mapper.Map<RegisterCommand>(request);
        var result = await _mediator.Send(command);

        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpGet]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var command = _mapper.Map<LoginQuery>(request);

        var result = await _mediator.Send(command);

        return Ok(_mapper.Map<LoginResponse>(result));
    }

    [HttpGet]
    [Route("hello")]
    [Authorize]
    public string Greet()
    {
        return "Hello";
    }
}