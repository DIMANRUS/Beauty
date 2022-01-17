using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Beauty.Helpers {
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