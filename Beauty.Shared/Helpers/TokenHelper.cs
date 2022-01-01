using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;

namespace Beauty.Shared.Helpers {
    public class TokenHelper { 
        private readonly IEnumerable<Claim> _claims;
        public TokenHelper(string token) =>
            _claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;

        public string GetName()
            => _claims.First(c => c.Type == ClaimTypes.Name).Value;
        public string GetNameIdentifer()
            => _claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        public string GetEmail()
             => _claims.First(c => c.Type == ClaimTypes.Email).Value;
        public string GetRole()
             => _claims.First(c => c.Type == ClaimTypes.Role).Value;
    }
}