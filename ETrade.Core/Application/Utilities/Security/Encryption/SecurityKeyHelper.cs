using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Application.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        // Şifreleme olan sistemlerde her şeyi bir byte array formatında veriyor olmamız gerekiyor.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}