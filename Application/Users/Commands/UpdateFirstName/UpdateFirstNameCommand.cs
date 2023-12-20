using MediatR;
using Contracts;

namespace Application.Commands;

public record UpdateFirstNameCommand(
    string Id,
    string FirstName
) : IRequest<CommonUserResult>;