using Domain.Entites;
using Xunit;

namespace AppTests;

public class UserEntityCreationTest
{
    [Fact]
    public void WhenCreatingAnUser()
    {
        // Arrange

        // Act
        var user = User.Create(
            "John",
            "Doe",
            "john.doe@email.com",
            "Pass@01234"
        );

        // Assert
        Assert.NotNull(user);
        Assert.IsType<User>(user);
        Assert.Equal("John", user.FirstName);
        Assert.Equal("Doe", user.LastName);
        Assert.Equal("john.doe@email.com", user.Email);
    }
}