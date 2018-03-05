using System;
using CurrencyCalculator.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyCalculator.Tests
{
    [TestClass]
    public class CurrencyServiceTests
    {
        [TestMethod]
        public void CurrencyService_Ctor_Creates_An_Instance_of_service()
        {
            //Arrange
            var currencyService = new CurrencyService();

            //Act

            //Assert
            Assert.IsNotNull(currencyService);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CurrencyService_ConvertMethod_Passing_0_Returns_Exception()
        {
            //Arrange
            var currencyService = new CurrencyService();

            //Act
            var result = currencyService.Convert(0, Models.CurrencyType.GBP, Models.CurrencyType.USD);

            //Assert Show throw argument out of range exception.
        }

        [TestMethod]
        public void CurrencyService_Calling_GetCurrencyConversions_Returns_Data()
        {
            //Arrange
            var currencyService = new CurrencyService();

            //Act
            var rates = currencyService.GetCurrencyConversions();

            //Assert
            Assert.IsNotNull(rates);
            Assert.IsTrue(rates.Count > 0);
        }

        [TestMethod]
        public void CurrencyService_Convert_100_GBP_To_USD_Returns_135_58()
        {
            //Arrange
            var currencyService = new CurrencyService();

            //Act
            var result = currencyService.Convert(100, Models.CurrencyType.GBP, Models.CurrencyType.USD);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 0);
            Assert.IsTrue(result == 135.58m);

        }

    }
}
