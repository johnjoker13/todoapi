using Application.Common;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands;

public class GetAllTodoItemsByUserIdQueryHandler
    : IRequestHandler<GetAllTodoItemsByUserIdQuery, IEnumerable<TodoItem>>
{

    private readonly ITodoItemRepository _todoItemRepository;
    private readonly IUserRepository _userRepository;

    public GetAllTodoItemsByUserIdQueryHandler(
        ITodoItemRepository todoItemRepository,
        IUserRepository userRepository
    )
    {
        _todoItemRepository = todoItemRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<TodoItem>> Handle(
        GetAllTodoItemsByUserIdQuery query,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;

        if (_userRepository.GetById(query.UserId) is null)
        {
            throw new NotFoundException($"Id: {query.UserId} not found!");
        }

        return _todoItemRepository.GetAllByUserId(query.UserId);
    }
}
