
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using user_auth.Models;

namespace user_auth.Services;

public class TokenService
{
    public void GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.BornDate.ToString()),
        };

        // Gerando uma chave geração do token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ABHDVTYV10JDBYVEHBDHJB52UBD6SDFF84D"));

        // Gerando as chaves de acesso
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Configurações do Token
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
        );
    }
}