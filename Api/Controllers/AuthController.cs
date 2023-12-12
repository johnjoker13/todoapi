using System.Net;
using Application.Commands;
using Contracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/")]
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
}