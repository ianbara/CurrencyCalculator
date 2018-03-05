using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyCalculator.Models
{
    public class CurrencyConversion
    {
        public CurrencyType CurrencyTypeFrom { get; set; }
        public CurrencyType CurrencyTypeTo { get; set; }
        public decimal Rate { get; set; }
    }
}
