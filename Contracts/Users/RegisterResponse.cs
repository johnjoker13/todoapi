namespace Contracts;

public record RegisterResponse(
    string Id,
    string Name,
    string LastName,
    string Email
);