namespace Auth.Application.DTOs;

public class JwtTokenDto
{
    public string JwtToken { get; set; } = default!;

    public string RefreshToken { get; set; } = default!;

    public DateTime Expires { get; set; }
}