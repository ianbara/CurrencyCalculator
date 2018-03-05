using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurrencyCalculator.Models;
using CurrencyCalculator.Service;
using CurrencyConvertor.Web.ViewModels;

namespace CurrencyCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public HomeController()
        {
            _currencyService = new CurrencyService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CurrencyConvertorTool()
        {
            var currencyToolViewModel = new CurrencyToolViewModel();
            var rates = _currencyService.GetCurrencyConversions().Where(c => c.CurrencyTypeTo != c.CurrencyTypeFrom);
            currencyToolViewModel.CurrencyTypesList = new SelectList(rates, "CurrencyTypeTo", "CurrencyTypeTo");
            return PartialView("_CurrencyConvertorTool", currencyToolViewModel);
        }

        [HttpPost]
        public PartialViewResult CurrencyConvertorTool(CurrencyToolViewModel model)
        {
            model.OutputAmount = _currencyService.Convert(model.InputAmount, model.CurrencyTypeFrom, model.CurrencyTypeTo);
            var rates = _currencyService.GetCurrencyConversions().Where(c => c.CurrencyTypeTo != c.CurrencyTypeFrom);
            model.CurrencyTypesList = new SelectList(rates, "CurrencyTypeTo", "CurrencyTypeTo");
            return PartialView("_CurrencyConvertorTool", model);
        }

        [HttpPost]
        public PartialViewResult CalculateAmount(CurrencyToolViewModel model)
        {
            if (model.CurrencyTypeFrom == model.CurrencyTypeTo)
            {
                return PartialView("_CalculationResult", 0);
            }
            var calculationResult = _currencyService.Convert(model.InputAmount, model.CurrencyTypeFrom, model.CurrencyTypeTo);
            return PartialView("_CalculationResult", calculationResult);
        }

        public PartialViewResult Rates()
        {
            return PartialView("_Rates", _currencyService.GetCurrencyConversions());
        }

        [HttpPost]
        public PartialViewResult CurrentRate(string currencyType)
        {
            if (currencyType != null)
            {
                var currenyTypeEnum = Enum.Parse(typeof(CurrencyType), currencyType);
                if (currenyTypeEnum != null)
                {
                    return PartialView("_CurrentRate", _currencyService.GetCurrencyConversion((CurrencyType)currenyTypeEnum));
                }
            }
            return null;
        }
    }
}