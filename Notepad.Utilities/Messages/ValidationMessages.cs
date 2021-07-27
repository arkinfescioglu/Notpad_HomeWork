namespace Notepad.Utilities.Messages
{
    public static class ValidationMessages
    {
        
        public static string NoAccess = "Bu işlem için yeterli yetkiniz bulunmamaktadır.";
        
        public static string ParamMissing(string paramName)
        {
            return $"{paramName} Parametresi Eksik.";
        }


        public static string ParamNotFound(string paramName)
        {
            return $"{paramName} Parametresi Bulunamadı.";
        }

        public static string ParamRequired(string paramName)
        {
            return $"{paramName} Alanı Boş Bırakılamaz.";
        }

        public static string ParamFormat(string paramName)
        {
            return $"{paramName} Alanı Yanlış Formatta.";
        }

        public static string MaxCanBe(string paramName, int number)
        {
            return $"{paramName} Alanı En Fazla {number} Karakter Olabilir.";
        }

        public static string MinCanBe(string paramName, int number)
        {
            return $"{paramName} Alanı En Az {number} Karakter Olabilir.";
        }

        public static string RequiredAccountType(string paramName, string accountType)
        {
            return $"{accountType} hesapları için {paramName} alanı zorunludur.";
        }
        
    }
}