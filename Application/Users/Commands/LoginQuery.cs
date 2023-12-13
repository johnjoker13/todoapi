using Contracts;
using MediatR;

namespace Application.Commands;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<LoginResult>;