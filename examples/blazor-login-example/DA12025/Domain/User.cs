namespace Domain;

public class User
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public User(string name, string lastname, string email, string password, string role)
    {
        Name = name;
        LastName = lastname;
        Email = email;
        Password = password;
        Role = role;
    }
}