using System.Text.RegularExpressions;
using System.Web;
using Slugify;

namespace Notepad.Utilities.Helpers
{
    public static class SlugMaker
    {
        public static string GenerateSlug(string phrase)
        {
            string str = phrase;
            str = ToUrlSlug(str);
            str = HttpUtility.HtmlDecode(str);
            return str;
        }

        public static string ToUrlSlug(string value)
        {
            SlugHelper helper = new SlugHelper();
            //First to lower case
            value = value.ToLowerInvariant();

            //Replace spaces
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars
            value = Regex.Replace(value, @"/[^a-z0-9ก-๙เแ]/i", "-", RegexOptions.Compiled);
            value = Regex.Replace(value, @"/-+/", "-", RegexOptions.Compiled);

            //Trim dashes from end
            value = value.Trim('-', '_');

            //Replace double occurences of - or _
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            value = Regex.Replace(value, @"/-$|^-/", "", RegexOptions.Compiled);

            value = Regex.Replace(value, @"ü", "u", RegexOptions.Compiled);
            value = Regex.Replace(value, @"Ü", "u", RegexOptions.Compiled);
            value = Regex.Replace(value, @"ğ", "g", RegexOptions.Compiled);
            value = Regex.Replace(value, @"Ğ", "g", RegexOptions.Compiled);
            value = Regex.Replace(value, @"ş", "s", RegexOptions.Compiled);
            value = Regex.Replace(value, @"Ş", "s", RegexOptions.Compiled);
            value = Regex.Replace(value, @"ç", "c", RegexOptions.Compiled);
            value = Regex.Replace(value, @"Ç", "c", RegexOptions.Compiled);
            value = Regex.Replace(value, @"ö", "o", RegexOptions.Compiled);
            value = Regex.Replace(value, @"Ö", "o", RegexOptions.Compiled);
            value = Regex.Replace(value, @"ı", "i", RegexOptions.Compiled);
            value = Regex.Replace(value, @"İ", "i", RegexOptions.Compiled);

            value = Regex.Replace(value, @"/[^A-Za-z0-9-]+/", "-", RegexOptions.Compiled);
            value = Regex.Replace(value, @"~<a[^>]*>(.*)<\/a>~ui", "-", RegexOptions.Compiled);

            value = helper.GenerateSlug(value);
            return value;
        }
    }
}