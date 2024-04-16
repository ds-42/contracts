using Core.Users.Domain;

namespace Auth.Domain;

public class RefreshToken
{
    public Guid RefreshTokenId { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    
    public DateTime Expired { get; set; }
}