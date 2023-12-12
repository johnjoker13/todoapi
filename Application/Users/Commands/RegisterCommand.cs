using Contracts;
using MediatR;

namespace Application.Commands;

public record RegisterCommand(
    string Name,
    string LastName,
    string Email,
    string Password
) : IRequest<RegisterResponse>;