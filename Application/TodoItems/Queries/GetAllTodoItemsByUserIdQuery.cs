using Domain.Entities;
using MediatR;

namespace Application.Commands;

public record GetAllTodoItemsByUserIdQuery(
    string UserId
) : IRequest<IEnumerable<TodoItem>>;