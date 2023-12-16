namespace Domain.Entities;

public class TodoItem
{
    public string Id { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Status { get; set; }
    public string UserId { get; set; } = null!;

    public TodoItem(
        string id,
        string description,
        bool status,
        string userId
    )
    {
        Id = id;
        Description = description;
        Status = status;
        UserId = userId;
    }

    public static TodoItem Create(
        string description,
        string userId
    )
    {
        return new(
            Guid.NewGuid().ToString(),
            description,
            false,
            userId
        );
    }
}