using Domain.Entites;

namespace Infrastructure.Persistence;

public interface IUserRepository
{
    void Create(User user);
    User? GetByEmail(string email);

    User? GetById(string id);

    User? UpdateFirstName(User user, string firstName);
}