using Application.Commands;
using Contracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class TodoItemController : MainController
{

    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public TodoItemController(
        ISender mediator,
        IMapper mapper
    )
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("todo/add-item")]
    public async Task<IActionResult> CreateTodoItem(AddTodoItemRequest request)
    {
        var command = _mapper.Map<AddTodoItemCommand>(request);

        var commandSent = await _mediator.Send(command);

        var result = _mapper.Map<AddTodoItemResponse>(commandSent);

        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpGet]
    [Route("todo/getall-by-userid")]
    public async Task<IActionResult> GetAllByUserId(GetAllTodoItemsByUserIdRequest request)
    {
        var query = _mapper.Map<GetAllTodoItemsByUserIdQuery>(request);
        var commandSent = await _mediator.Send(query);
        var result = _mapper
            .Map<IEnumerable<GetAllTodoItemsByUserIdResponse>>(commandSent);
        return Ok(result);
    }

}