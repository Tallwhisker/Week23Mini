using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker
{
    static class CurrencyConverter
    {
        static private string xmlUrl = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        //UpdateRates
        //ConvertTo
        static public decimal ConvertTo(decimal value, string currency, out decimal newValue)
        {
            newValue = 0;
            switch (currency)
            {
                case "USD":
                    newValue *= (decimal)1.5555;
                    break;

                case "SEK":
                    newValue *= (decimal)11.3755;
                    break;

                case "EUR":
                    break;

                default:
                    break;
            }
            return newValue;
        }

        static public void Update() 
        {
            //yada yada get new rates?
        }
    }
}
