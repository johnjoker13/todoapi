namespace Domain.Entites;

public class User
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        return new(
            Guid.NewGuid().ToString(),
            firstName,
            lastName,
            email,
            password
        );
    }
}