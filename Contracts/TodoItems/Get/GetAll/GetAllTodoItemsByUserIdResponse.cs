namespace Contracts;

public record GetAllTodoItemsByUserIdResponse(
    string Id,
    string Description,
    bool Status,
    string UserId
);