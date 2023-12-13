namespace Contracts;

public record LoginResponse(
    string Id,
    string Name,
    string LastName,
    string Email,
    string Token
);