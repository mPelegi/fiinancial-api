using Microsoft.IdentityModel.Tokens;

namespace Fiinancial.Api.Crosscutting.DTO.GeralCtx
{
    public class JwtDto
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ValidForMinutes { get; set; }
        public int RefreshTokenValidForMinutes { get; set; }
        public string SigningKey { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime NotBefore { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
