using CurrencyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCalculator.Service
{
    public interface ICurrencyService
    {
        List<CurrencyConversion> GetCurrencyConversions();
        CurrencyConversion GetCurrencyConversion(CurrencyType currencyType);
        decimal Convert(decimal inputAmount, CurrencyType convertFrom, CurrencyType convertTo);
    }
}
