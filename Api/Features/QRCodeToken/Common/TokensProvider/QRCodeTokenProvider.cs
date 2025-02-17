using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;
using System.Text;

namespace Api.Features.QRCodeToken.Common.TokensProvider
{
    public sealed class QRCodeTokenProvider(IConfiguration configuration)
    {
        public string Create(Guid id)
        {
            string secretKey = configuration["JwtQrCodeSecret:Secret"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(JwtRegisteredClaimNames.Sub,id.ToString())
                    ]),
                SigningCredentials = credentials,
             
                Audience = configuration["Jwt:Audience"]


            };
            var handler = new JsonWebTokenHandler();
            var token = handler.CreateToken(tokenDescription);
            return token;
            
        }
    }
}
