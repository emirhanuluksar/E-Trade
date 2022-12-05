using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Infrastructure.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string CustomerRegistered = "Kayıt olundu";
        public static string CustomerNotFound = "Böyle bir Müşteri bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string CustomerAlreadyExists = "Müşteri daha önceden kayıt olmuş";
        public static string AccessTokenCreated = "Token oluşturuldu!";
        public static string CategoryListed = "Kategori listelendi";
        public static string ProductAdded = "Ürün eklendi";

        public static string ProductCountOfCategoryError { get; internal set; }
        public static string ProductNameAlreadyExists { get; internal set; }
        public static string CategoryLimitExceded { get; internal set; }
        public static string ProductDeleted { get; internal set; }
        public static string ProductsListed { get; internal set; }
        public static string MaintenanceTime { get; internal set; }
    }
}