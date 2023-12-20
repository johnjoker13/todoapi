using Domain.Entites;

namespace Contracts;

public record CommonUserResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email
);