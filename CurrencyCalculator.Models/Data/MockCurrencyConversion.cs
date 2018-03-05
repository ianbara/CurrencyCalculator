using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyCalculator.Models.Data
{
    public class MockCurrencyConversion
    {
        public List<CurrencyConversion> GetCurrencyConvertionData()
        {
            var currencyConvertionList = new List<CurrencyConversion>();
            currencyConvertionList.Add(new CurrencyConversion()
            {
                CurrencyTypeFrom = CurrencyType.GBP,
                CurrencyTypeTo = CurrencyType.USD,
                Rate = 1.3558m
            });
            currencyConvertionList.Add(new CurrencyConversion()
            {
                CurrencyTypeFrom = CurrencyType.GBP,
                CurrencyTypeTo = CurrencyType.AUD,
                Rate = 1.7277m
            });
            currencyConvertionList.Add(new CurrencyConversion()
            {
                CurrencyTypeFrom = CurrencyType.GBP,
                CurrencyTypeTo = CurrencyType.EUR,
                Rate = 1.1076m
            });
            return currencyConvertionList;

        }
    }
}

