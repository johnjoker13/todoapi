using Domain.Entities;

namespace Infrastructure.Persistence;

public class TodoItemRepository : ITodoItemRepository
{

    private readonly TodoDbContext _dbContext;

    public TodoItemRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(TodoItem item)
    {
        _dbContext.TodoItems.Add(item);
        _dbContext.SaveChanges();
    }

    public IEnumerable<TodoItem> GetAllByUserId(string userId)
    {
        return _dbContext.TodoItems
            .Where(x => x.UserId == userId)
            .ToList();
    }
}