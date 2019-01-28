using System.Linq;

namespace ConsoleApp1.SO
{
    public static class GetLanguages
    {
        public static string GetLanguageNames()
        {
            var allCultures = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures);
            string countrycode = "ar-SA";
            string langname = allCultures.FirstOrDefault(c => c.Name == countrycode).NativeName;

            return langname;
        }
    }
}
