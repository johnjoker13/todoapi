using BC = BCrypt.Net.BCrypt;
using MediatR;
using Contracts;
using Domain.Entites;
using Infrastructure.Persistence;
using Application.Common;

namespace Application.Commands;

public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, CommonUserResult>
{

    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CommonUserResult> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;

        if (_userRepository.GetByEmail(command.Email) is not null)
        {
            throw new ConflictException($"Email: {command.Email} not available!");
        }

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            BC.HashPassword(command.Password)
        );

        _userRepository.Create(user);

        return new CommonUserResult(
            user
        );
    }
}