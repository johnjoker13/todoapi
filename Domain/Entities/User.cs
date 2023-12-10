namespace Domain.Entites;

public class User
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public User(
        string id,
        string name,
        string lastName,
        string email,
        string password
    )
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User CreateUser(
        string name,
        string lastName,
        string email,
        string password
    )
    {
        return new(
            Guid.NewGuid().ToString(),
            name,
            lastName,
            email,
            password
        );
    }
}