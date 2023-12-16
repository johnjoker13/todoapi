using System.Security.Authentication;
using Application.Common;
using Contracts;
using Domain.Entites;
using Infrastructure.Persistence;
using MediatR;
using BC = BCrypt.Net.BCrypt;

namespace Application.Commands;

public class LoginQueryHandler
    : IRequestHandler<LoginQuery, LoginResult>
{

    private readonly IUserRepository _userRepository;
    private readonly IJwtGenerator _jwtGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtGenerator jwtGenerator)
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<LoginResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;



        if (_userRepository.GetByEmail(query.Email) is not User user)
        {
            throw new InvalidCredentialException($"User with email: {query.Email} does not exists");
        }


        if (BC.Verify(query.Password, user.Password) is not true)
        {
            throw new InvalidCredentialException("Password is incorrect.");
        }

        var token = _jwtGenerator.GenerateToken(user);

        return new LoginResult(
            user,
            token
        );
    }
}