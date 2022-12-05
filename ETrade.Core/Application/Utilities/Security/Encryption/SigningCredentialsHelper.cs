using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Application.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            // webapinin kullanabileceği jwt lerin oluşturulabilmesi için credential sisteme girmek için elimizde olanlardır.
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); // imzalama nesnesini döndürücek.
        }
    }
}