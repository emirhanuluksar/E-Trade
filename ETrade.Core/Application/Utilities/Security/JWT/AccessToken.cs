using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Utilities.Security.JWT
{
    public class AccessToken // Erişim anahtarı 
    {
        public string Token { get; set; } // Token
        public DateTime Expiration { get; set; } // Tokenın ne zaman sonlanacağının bilgisi
    }
}