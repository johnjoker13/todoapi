using Contracts;
using MediatR;

namespace Application.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<CommonUserResult>;