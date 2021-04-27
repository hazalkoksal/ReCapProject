using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //All
        public static string MaintenanceTime = "Sistem bakımda";

        //Car
        public static string CarAdded = "Araç eklendi";
        public static string CarListed = "Araçlar listelendi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string DailyPriceInvalid = "Fiyat bilgisi geçersiz";

        //Rental
        public static string CarRanted = "Araç kiralandı";
        public static string CarAvaliable = "Araç kiralanabilir";
        public static string CarNotAvaliable = "Seçilen tarih aralığında araç henüz teslim edilmediği için kiralanamaz";
        public static string NotEnoughFindexPoint = "Müşterinin findeks puanı aracı kiralamak için yeterli değil";

        //CarImage
        public static string ImageCountOfCarError = "Bir aracın en fazla 5 fotoğrafı olabilir";

        //Card
        public static string CardValid = "Ödeme işlemi gerçekleştirildi";
        public static string CardInvalid = "Kredi Kartı bilgileriniz geçersiz";

        //Authorization
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "İşlem başarılı";
    }
}
