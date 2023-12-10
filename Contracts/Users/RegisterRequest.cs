namespace Contracts.Users;

public record RegisterRequest(
    string Name,
    string LastName,
    string Email,
    string Password
);