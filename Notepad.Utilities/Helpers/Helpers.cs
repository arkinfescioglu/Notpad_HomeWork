using System;
using System.Web;

namespace Notepad.Utilities.Helpers
{
    public static class Helpers
    {
        public static int RandomNumber(int min = 100000, int max = 999999999)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static string MakeToken()
        {
            string textForToken = $"{RandomNumber()} asdasd {DateTime.Now} asdasd {RandomNumber()} {DateTime.Now}";
            string hashValue    = Hash.Make(textForToken);
            hashValue = Hash.Make($"{hashValue} {textForToken}");
            return Hash.Make(hashValue);
        }
        
        public static string CreateSlug(string phrase)
        {
            return SlugMaker.GenerateSlug(phrase);
        }

        public static string ConvertAccountType(string accountType)
        {
            string accountTypeDescription = accountType switch
            {
                    "1" => "İşletme",
                    "2" => "Müzisyen",
                    "3" => "Dinleyici",
                    _   => null
            };

            return accountTypeDescription;
        }
        
        public static string CleanHtml(string input)
        {
            return HttpUtility.HtmlAttributeEncode(input);
        }

        public static string MakeHash(string input)
        {
            return Hash.Make(input);
        }

        public static bool CheckHash(string value, string hashedValue)
        {
            return Hash.CheckConstraint(value, hashedValue);
        }
    }
}