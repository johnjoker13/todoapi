using Domain.Entities;

namespace Infrastructure.Persistence;

public interface ITodoItemRepository
{
    void Create(TodoItem item);
    IEnumerable<TodoItem> GetAllByUserId(string userId);
}