using BC = BCrypt.Net.BCrypt;
using MediatR;
using Contracts;
using Domain.Entites;
using Infrastructure.Persistence;

namespace Application.Commands;

public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, RegisterResponse>
{

    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<RegisterResponse> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;

        if (_userRepository.GetByEmail(command.Email) is not null)
        {
            throw new Exception("User exists!");
        }

        var user = User.Create(
            command.Name,
            command.LastName,
            command.Email,
            BC.HashPassword(command.Password)
        );

        _userRepository.Create(user);

        return new RegisterResponse(
            user.Id,
            user.Name,
            user.LastName,
            user.Email
        );
    }
}