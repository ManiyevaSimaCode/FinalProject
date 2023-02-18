

using Core.Utilities.Security.Encryption;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Utilities.Security.JWT
{
    public class JWTHelper : ITokenHelper
    {
        private readonly IConfiguration _configuration;
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JWTHelper(IConfiguration configuration, TokenOptions tokenOption, DateTime accessTokenExpiration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration=DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration);
        }

        public AccessToken CreateToken( List<Claim> claims)
        {
            JwtHeader jwtHeader = CreateJwtHeader(_tokenOptions);
            JwtPayload jwtPayload = CreateJwtPayload(_tokenOptions, claims);
            JwtSecurityToken jwtSecurityToken = CreateJwtSecurityToken(jwtHeader, jwtPayload);
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
         
        }






        private JwtHeader CreateJwtHeader(TokenOptions tokenOptions)
        {
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SignInCredentialsHelper.CreateSignInCredentials(securityKey);
            return new JwtHeader(signingCredentials);
        }

        private JwtPayload CreateJwtPayload(TokenOptions tokenOptions,List<Claim>claims)
        {
            return new JwtPayload
                (
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                claims:claims,
                notBefore:DateTime.UtcNow,
                expires:_accessTokenExpiration
                );
        }
        private JwtSecurityToken CreateJwtSecurityToken(JwtHeader jwtHeader,JwtPayload jwtPayload)
        {
            return new JwtSecurityToken(jwtHeader, jwtPayload);
        }
    }
}
