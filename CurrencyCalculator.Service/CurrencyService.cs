using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyCalculator.Models;
using CurrencyCalculator.Models.Data;

namespace CurrencyCalculator.Service
{
    public class CurrencyService : ICurrencyService
    {
        public decimal Convert(decimal inputAmount, CurrencyType convertFrom, CurrencyType convertTo)
        {
            if (inputAmount == 0) throw new ArgumentOutOfRangeException("input");
            if (convertTo == convertFrom) throw new ArgumentException("convertion from and to are the same");

            var convertionRates = GetCurrencyConversions();
            decimal convertedAmount = 0;

            CurrencyConversion currencyConvertion = new CurrencyConversion();
            if (convertionRates.Any(r => r.CurrencyTypeFrom == convertFrom && r.CurrencyTypeTo == r.CurrencyTypeTo))
            {
                currencyConvertion = convertionRates.FirstOrDefault((r => r.CurrencyTypeFrom == convertFrom && r.CurrencyTypeTo == convertTo));
            }

            if (currencyConvertion.Rate > 0)
            {
                convertedAmount = inputAmount * currencyConvertion.Rate;
            }

            return convertedAmount;
        }

        public CurrencyConversion GetCurrencyConversion(CurrencyType currencyType)
        {
            var mockData = new MockCurrencyConversion();

            return mockData.GetCurrencyConvertionData().Where(c => c.CurrencyTypeTo == currencyType).FirstOrDefault();
        }

        public List<CurrencyConversion> GetCurrencyConversions()
        {
            var mockData = new MockCurrencyConversion();

            return mockData.GetCurrencyConvertionData();

        }
    }
}
