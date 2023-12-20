namespace Contracts;

public record RegisterResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email
);