using Domain.Entites;

namespace Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly TodoDbContext _context;

    public UserRepository(TodoDbContext context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? GetByEmail(string email)
    {
        return _context.Users.SingleOrDefault(x => x.Email == email);
    }

    public User? GetById(string id)
    {
        return _context.Users.SingleOrDefault(x => x.Id == id);
    }
}