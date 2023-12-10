using Domain.Entites;
using MediatR;

namespace Application.Commands;

public record CreateUserCommand(
    string Name,
    string LastName,
    string Email,
    string Password
) : IRequest<User>;