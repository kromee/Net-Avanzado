using System;
using System.Globalization;

namespace BackEnd
{
    public class CultureScope : IDisposable
    {
        private readonly CultureInfo _originalCulture;
        private readonly CultureInfo cultureUICulture;

        public CultureScope(CultureInfo culture) {
            _originalCulture = Thread.CurrentThread.CurrentCulture;
            _originalCulture = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }


        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _originalCulture;
            Thread.CurrentThread.CurrentUICulture = _originalCulture;

        }
    }
}

