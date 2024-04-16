using Core.Users.Domain.Enums;

namespace Core.Users.Domain;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = default!;
    public string Password { get; set; } = default!;
    public UserRole Role { get; set; }
}
