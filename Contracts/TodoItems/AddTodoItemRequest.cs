namespace Contracts;

public record AddTodoItemRequest(
    string Description,
    string UserId
);