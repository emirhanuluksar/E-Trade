using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities.Concrete;

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

        public static string ProductCountOfCategoryError = "Kategori sınırı aşıldı";
        public static string ProductNameAlreadyExists = "Bu isimde bir ürün zaten var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldı";
        public static string ProductDeleted = "Ürün kaldırıldı!";
        public static string ProductsListed = "Ürünler listelendi";
        public static string MaintenanceTime = "BAKIMDA!";
        public static string ProductPurchased = "Ürün satın alındı";
        public static string OrderCreated = "Sipariş oluşturuldu!";
        internal static Customer Deneme;
    }
}