using Contracts;
using MediatR;

namespace Application.Commands;

public record AddTodoItemCommand(
    string Description,
    string UserId
) : IRequest<AddTodoItemResult>;