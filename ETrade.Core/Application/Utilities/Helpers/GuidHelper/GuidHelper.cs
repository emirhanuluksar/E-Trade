using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Utilities.Helpers.GuidHelper
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {

            return Guid.NewGuid().ToString(); //burada yüklediğimiz dosyamız için eşsiz bir isim oluşturduk.
                                              //Yani dosya eklerken dosyanın adı kendi olmasın,
                                              //biz ona eşsiz bir isim oluşturalım ki aynı isimde başka bir dosya varsa çakışmasınlar.
                                              //Guid.NewGuid()=> bu metot bize eşsiz bir değer oluşturdu.
        }
    }
}