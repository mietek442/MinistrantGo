using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Models
{
    public class QrCodeToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Token { get; private set; }
        public bool IsActive { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        public QrCodeToken()
        {
            Token = GenerateToken().ToString();
        }

        private JwtSecurityToken GenerateToken()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Id.ToString())
            };

            var key = new SymmetricSecurityKey(Guid.NewGuid().ToByteArray());
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: "yourIssuer",
                audience: "yourAudience",
                claims: claims,       
                signingCredentials: creds
            );
        }
    }
}
