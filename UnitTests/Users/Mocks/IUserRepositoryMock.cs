using Domain.Entites;
using Infrastructure.Persistence;
using Moq;

namespace UnitTests;

public static class IUserRepositoryMock
{
    public static Mock<IUserRepository> GetUserRepositoryMock()
    {

        var mock = new Mock<IUserRepository>();

        mock.Setup(x => x.Create(It.IsAny<User>()))
            .Callback(() => { return; });

        return mock;
    }
}