using Domain.Entities;

namespace Infrastructure.Persistence;

public class TodoItemRepository : ITodoItemRepository
{

    private readonly UserDbContext _dbContext;

    public TodoItemRepository(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(TodoItem item)
    {
        _dbContext.TodoItems.Add(item);
        _dbContext.SaveChanges();
    }
}