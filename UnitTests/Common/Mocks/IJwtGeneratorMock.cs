using Application.Common;
using Domain.Entites;
using Moq;

namespace UnitTests;

public static class IJwtGeneratorMock
{
    public static Mock<IJwtGenerator> GetJwtGeneratorMock()
    {

        var mock = new Mock<IJwtGenerator>();

        var user = User.Create(
            "John",
            "Doe",
            "john.doe@email.com",
            "Pass@1234"
        );

        mock.Setup(x => x.GenerateToken(It.IsAny<User>()))
            .Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI4M2EwOWY2Mi0wODM2LTQxNmEtYTQwMy03MjdhNGY2N2YxYjUiLCJnaXZlbl9uYW1lIjoiS3lyaWUiLCJmYW1pbHlfbmFtZSI6IklydmluZyIsImp0aSI6IjQ5OWVhYjNiLTMzMDEtNDQwZS1iN2RmLTQxNGVlNjU2M2YyZSIsImV4cCI6MTcwMjc0OTQwMSwiaXNzIjoiVG9kbyIsImF1ZCI6IlRvZG8ifQ.We3r_ewOo_i_CbPxcomsnIFUiQ48T2mZ3YKy9kDeihM");

        return mock;
    }
}