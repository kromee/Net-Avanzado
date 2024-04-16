using System;
using System.Collections.Generic;
using System.Globalization;





namespace Translations
{

    public static class HeaderHelper
    {
       /* public static CultureInfo GetCultureInfo(this IHeaderDictionary header)
        {
            if (header == null)
                throw new ArgumentNullException(nameof(header));

            using (new CultureScope(new CultureInfo("en")))
            {
                var languages = new List<(string, decimal)>();
                string acceptedLanguage = header["Accept-Language"].ToString ();

                if (string.IsNullOrEmpty(acceptedLanguage))
                {
                    return new CultureInfo("es");
                }

                string[] acceptedLanguages = acceptedLanguage.Split(',');
                foreach (string accLang in acceptedLanguages)
                {
                    var languageDetails = accLang.Split(';');
                    string languageCode = languageDetails[0].Trim();
                    decimal quality = 1; // Default quality
                    if (languageDetails.Length > 1)
                    {
                        string qualityStr = languageDetails[1].Replace("q=", "").Trim();
                        if (!decimal.TryParse(qualityStr, out quality))
                        {
                            // Handle parse error, perhaps log it
                        }
                    }
                    languages.Add((languageCode, quality));
                }

                string languageToSet = languages.OrderByDescending(a => a.Item2).First().Item1;
                return CultureInfo.CreateSpecificCulture(languageToSet);
            }
        }*/
    }
}

