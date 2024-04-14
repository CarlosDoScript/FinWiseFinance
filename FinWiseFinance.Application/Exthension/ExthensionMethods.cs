using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinWiseFinance.Application.Exthension
{
    public static class ExthensionMethods
    {
        public static string PrimeiraLetraMaiuscula(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(texto.ToLower());
        }
    }
}
