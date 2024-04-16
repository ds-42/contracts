using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Users.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Application.Services;

public class CreateJwtTokenService : ICreateJwtTokenService
{
    private readonly IConfiguration _configuration;

    public CreateJwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string CreateJwtToken(User user, DateTime dateExpires)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Login),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, ((int)user.Role).ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(_configuration["Jwt:Issuer"]!, _configuration["Jwt:Audience"]!, claims,
            expires: dateExpires, signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor)!;
    }
}