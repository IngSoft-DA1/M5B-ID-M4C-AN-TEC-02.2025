namespace Services.Models;

public class UserLoginDTO
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserLoginDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }
}