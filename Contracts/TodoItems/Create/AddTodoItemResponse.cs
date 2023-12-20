namespace Contracts;

public record AddTodoItemResponse(
    string Id,
    string Description,
    bool Status,
    string UserId
);