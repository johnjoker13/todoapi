using Application.Commands;
using Contracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class UserController : MainController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UserController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPatch]
    [Route("user/update-firstname")]
    public async Task<IActionResult> UpdateUserFirstName(UpdateFirstNameRequest request)
    {
        var command = _mapper.Map<UpdateFirstNameCommand>(request);

        var result = await _mediator.Send(command);

        return Ok(_mapper.Map<CommonUserResponse>(result));
    }
}