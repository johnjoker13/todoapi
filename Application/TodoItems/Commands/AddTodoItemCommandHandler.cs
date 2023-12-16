using Contracts;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands;

public class AddTodoItemCommandHandler
    : IRequestHandler<AddTodoItemCommand, AddTodoItemResult>
{

    private readonly ITodoItemRepository _todoItemRepository;

    public AddTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<AddTodoItemResult> Handle(
        AddTodoItemCommand command,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;

        var todoItem = TodoItem.Create(
            command.Description,
            command.UserId
        );

        _todoItemRepository.Create(todoItem);

        return new AddTodoItemResult(
            todoItem
        );

    }
}
