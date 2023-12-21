using Application.Commands;
using Contracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[AllowAnonymous]
public class AuthController : MainController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("auth/register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {

        var command = _mapper.Map<RegisterCommand>(request);
        var commandSent = await _mediator.Send(command);

        var result = _mapper.Map<CommonUserResponse>(commandSent);

        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpGet]
    [Route("auth/login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var command = _mapper.Map<LoginQuery>(request);

        var result = await _mediator.Send(command);

        return Ok(_mapper.Map<LoginResponse>(result));
    }
}