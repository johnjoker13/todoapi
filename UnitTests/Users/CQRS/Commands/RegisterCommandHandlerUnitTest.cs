using System;
using System.Threading;
using Application.Commands;
using Contracts;
using Domain.Entites;
using Infrastructure.Persistence;
using MediatR;
using Moq;
using Xunit;

namespace UnitTests;

public class RegisterCommandHandlerUnitTest
{

    private readonly Mock<IUserRepository> mockRepository;

    public RegisterCommandHandlerUnitTest()
    {
        mockRepository = IUserRepositoryMock.GetUserRepositoryMock();
    }

    [Fact]
    public async void GivenRegisterCommand_WhenValid_AddsAndReturnsVoid()
    {
        // Arrange

        var command = new RegisterCommand(
            "John",
            "Doe",
            "john.doe@email.com",
            "Pass@1234"
        );

        var handler = new RegisterCommandHandler(mockRepository.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<RegisterResult>(result);
        Assert.IsType<User>(result.User);
        Assert.Equal("John", result.User.FirstName);
        Assert.Equal("Doe", result.User.LastName);
        Assert.Equal("john.doe@email.com", result.User.Email);
    }
}
