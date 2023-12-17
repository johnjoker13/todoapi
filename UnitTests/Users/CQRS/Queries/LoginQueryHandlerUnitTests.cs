using System;
using System.Threading;
using Application.Commands;
using Application.Common;
using Contracts;
using Domain.Entites;
using Infrastructure.Persistence;
using Moq;
using Xunit;

namespace UnitTests;

public class LoginQueryHandlerUnitTests
{

    private readonly Mock<IUserRepository> mockRepository;
    private readonly Mock<IJwtGenerator> mockJwtGenerator;

    public LoginQueryHandlerUnitTests()
    {
        mockRepository = IUserRepositoryMock.GetUserRepositoryMock();
        mockJwtGenerator = IJwtGeneratorMock.GetJwtGeneratorMock();
    }

    [Fact]
    public async void GivenLoginQuery_IfValid_ReturnsUserInfoAndToken()
    {
        // Arrange
        var query = new LoginQuery(
            "john.doe@email.com",
            "Pass@1234"
        );

        var user = User.Create(
            "John",
            "Doe",
            "john.doe@email.com",
            "$2a$11$J5lXR8Oh/3l7NEDYFa6maencOLnDHdLAU8Y6IT1TnvFTfqpdzleX6"
        );

        mockRepository.Setup(x => x.GetByEmail(It.IsAny<string>()))
            .Returns(user);

        var handler = new LoginQueryHandler(mockRepository.Object, mockJwtGenerator.Object);
        // Act
        var result = await handler.Handle(query, CancellationToken.None);
        // Assert
        Assert.NotNull(result.Token);
        Assert.IsType<LoginResult>(result);
        Assert.IsType<User>(result.User);
        Assert.NotEmpty(result.Token);
        Assert.IsType<string>(result.Token);
    }
}