using Domain.Entites;

namespace Application.Common;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}