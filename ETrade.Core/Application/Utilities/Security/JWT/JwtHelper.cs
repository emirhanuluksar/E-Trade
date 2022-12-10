using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Extensions;
using Application.Utilities.Security.Encryption;
using Domain.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Utilities.Security.JWT
{
        public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } // IConfigruation bizim apimizdeki app settingsi okumamızı sağlıyor.
        private TokenOptions _tokenOptions = new TokenOptions();
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions.Audience = Configuration["TokenOptions:Audience"];
            _tokenOptions.Issuer = Configuration["TokenOptions:Issuer"];
            _tokenOptions.AccessTokenExpiration = Convert.ToInt32(Configuration["TokenOptions:AccessTokenExpiration"]);
            _tokenOptions.SecurityKey = Configuration["TokenOptions:SecurityKey"];
            

        }
        public AccessToken CreateToken(Customer customer, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, customer, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Customer customer,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(customer, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(Customer customer, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(customer.CustomerId.ToString());
            claims.AddEmail(customer.Email);
            claims.AddName($"{customer.FirstName} {customer.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.ClaimName).ToArray());

            return claims;
        }
    }
}