using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CurrencyCalculator.Models;

namespace CurrencyConvertor.Web.ViewModels
{
    public class CurrencyToolViewModel
    {
        public CurrencyToolViewModel()
        {
            InputAmount = 1000;
            CurrencyTypeFrom = CurrencyType.GBP;
            CurrencyTypeTo = CurrencyType.USD;
            CurrentRate = new CurrencyConversion()
            {
                CurrencyTypeFrom = CurrencyType.GBP,
                CurrencyTypeTo = CurrencyType.USD,
                Rate = 1.7277m
            };
        }

        [Required]
        public decimal InputAmount { get; set; }

        public CurrencyType CurrencyTypeFrom { get; set; }

        public CurrencyType CurrencyTypeTo { get; set; }

        public SelectList CurrencyTypesList { get; set; }

        public CurrencyConversion CurrentRate { get; set; }

        public decimal OutputAmount { get; set; }

    }
}
