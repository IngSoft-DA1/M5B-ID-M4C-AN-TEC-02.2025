namespace Services.Models;

public class UserDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    
    public UserDTO() {}

    public UserDTO(string name, string lastName, string email, string password, string role)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
        Role = role;
    }
}