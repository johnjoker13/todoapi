using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands;

public class GetAllTodoItemsByUserIdQueryHandler
    : IRequestHandler<GetAllTodoItemsByUserIdQuery, IEnumerable<TodoItem>>
{

    private readonly ITodoItemRepository _todoItemRepository;

    public GetAllTodoItemsByUserIdQueryHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<IEnumerable<TodoItem>> Handle(
        GetAllTodoItemsByUserIdQuery query,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;
        return _todoItemRepository.GetAllByUserId(query.UserId);
    }
}
