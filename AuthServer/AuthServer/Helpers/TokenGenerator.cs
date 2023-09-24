using AuthServer.Dtos;
using AuthServer.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthServer.Helpers

{
    public class TokenGenerator
    {
        public TokenResponse GetToken(User user, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, role),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Top Secret Key 112358")); 
            var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "SampleJwtServer",
                Audience = "SampleJwtClient",
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(2),
                NotBefore = DateTime.Now,
                SigningCredentials = signingCredential,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(createdToken);
            var refreshToken = GetRefreshToken();
            var token = new TokenResponse { AccessToken = accessToken, RefreshToken = refreshToken };
            return token;
        }


        #region private methods
        private static string GetRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        #endregion
    }
}
