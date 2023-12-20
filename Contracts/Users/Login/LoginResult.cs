using Domain.Entites;

namespace Contracts;

public record LoginResult(
    User User,
    string Token
);