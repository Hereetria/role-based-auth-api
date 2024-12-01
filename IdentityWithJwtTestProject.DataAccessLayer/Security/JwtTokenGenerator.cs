using IdentityWithJwtTestProject.DtoLayer.Dtos.TokenDtos;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IdentityWithJwtTestProject.DataAccessLayer.Security
{
    public class JwtTokenGenerator
    {
        public static Token GenerateToken(int expires)
        {

            if (JwtTokenDefaults.Key.Length < 32)
                throw new ArgumentException("Key must be at least 16 characters long.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddMinutes(expires);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string accessToken = tokenHandler.WriteToken(securityToken);
            string refreshToken = CreateRefreshToken();

            var token = new Token(accessToken, refreshToken, expireDate);

            return token;
        }

        public static string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
