using Application.Common;
using Contracts;
using Domain.Entites;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands;

public class UpdateFirstNameCommandHandler
    : IRequestHandler<UpdateFirstNameCommand, CommonUserResult>
{

    private readonly IUserRepository _userRepository;

    public UpdateFirstNameCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CommonUserResult> Handle(
        UpdateFirstNameCommand command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        User? user = _userRepository.GetById(command.Id) ??
            throw new NotFoundException($"User not found!");

        _userRepository.UpdateFirstName(user, command.FirstName);

        return new CommonUserResult(user);
    }
}