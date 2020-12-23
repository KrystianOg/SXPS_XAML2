using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SXPS_XAML.Enums
{
    public enum Currency
    {
        AUD,
        CAD,
        CHF,
        EUR,
        GBP,
        HKD,
        JPY,
        USD,
        PLN
    }


    public static class CurrencyExtension
    {
        private static IDictionary<string, Currency> toC = new Dictionary<string, Currency>()
        {
            {"AUD",Currency.AUD },
            {"CAD",Currency.CAD },
            {"CHF",Currency.CHF },
            {"EUR",Currency.EUR },
            {"GBP",Currency.GBP },
            {"HKD",Currency.HKD },
            {"JPY",Currency.JPY },
            {"USD",Currency.USD },
            {"PLN",Currency.PLN }
        };
        private static IDictionary<Currency, string> toS = new Dictionary<Currency, string>()
        {
            {Currency.AUD, "AUD"},
            {Currency.CAD, "CAD"},
            {Currency.CHF, "CHF"},
            {Currency.EUR, "EUR"},
            {Currency.GBP, "GBP"},
            {Currency.HKD, "HKD"},
            {Currency.JPY, "JPY"},
            {Currency.USD, "USD"},
            {Currency.PLN, "PLN"}
        };
        private static IDictionary<Currency, string> sym = new Dictionary<Currency, string>()
        {
            {Currency.AUD, "A$"},
            {Currency.CAD, "C$"},
            {Currency.CHF, "CHf"},
            {Currency.EUR, "€"},
            {Currency.GBP, "£"},
            {Currency.HKD, "HK$"},
            {Currency.JPY, "¥"},
            {Currency.USD, "$"},
            {Currency.PLN, "zł"}
        };

        public static Currency toCurrency(string Currency)
        {
        return toC[Currency];
        }

        public static string ToString(this Currency c)
        {
            return toS[c];
        }

        public static string Symbol(this Currency c)
        {
            return sym[c];
        }

    }

    public static class Exchange 
    {
        private static IDictionary<Currency, double> shipping = new Dictionary<Currency, double>()
        {
            {Currency.GBP,5.0 },
            {Currency.AUD,15.2 },
            {Currency.CAD,14.96 },
            {Currency.CHF,10.45 },
            {Currency.EUR,10.0 },
            {Currency.HKD,89.13 },
            {Currency.JPY,1199.0 },
            {Currency.USD,11.5 },

        };
        private static IDictionary<Currency, double> PLN = new Dictionary<Currency, double>()
        {
            {Currency.GBP,4.7127 },
            {Currency.AUD,2.6268 },
            {Currency.CAD,2.7773 },
            {Currency.CHF,3.9837 },
            {Currency.EUR,4.3046 },
            {Currency.HKD,0.4598 },
            {Currency.JPY,0.0342 },
            {Currency.USD,3.6747 },
        };

        public static double ship(this Currency currency)
        {
            return shipping[currency];
        }

        public static double toPLN(this Currency currency)
        {
            return PLN[currency];
        }

        public static double toPLN(this Currency currency,double amount)
        {
            return PLN[currency] * amount;
        }

        public static void setExchange(Currency currency,double exchange)
        {

        }

        public static void getBestCurrency()
        {

        }
    }
}
