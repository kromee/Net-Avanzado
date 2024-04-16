using System;
using System.Globalization;
using BackEnd.Translations;

namespace BackEnd
{
	public class TraduccionErrores
	{
   
            private readonly CultureInfo _culture;
            public TraduccionErrores(CultureInfo culture)
            {
                _culture = culture;
            }

            public string PersonalProfile => LocalizationUtils<TraduccionErroresX>.GetValue("PersonalProfileNotFound", _culture);
            public string IdentityNotFound => LocalizationUtils<TraduccionErroresX>.GetValue("IdentityNotFound", _culture);
        }
    
}

