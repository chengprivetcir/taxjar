using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxServices;
using TaxServices.Models;

namespace UnitTestTaxServices
{
    [TestClass]
    public class TaxJarUnitTest
    {
        [TestMethod]
        public void TestGetRatesForZipCodeOnly()
        {
            var service = new TaxJarCalculator();
            var model = new TaxAddressModel
            {
                Zip = "30009"
            };
            var actual = service.GetRatesForLocation(model);

            Assert.AreEqual(0.0775m, actual.CombinedRate);
        }

        [TestMethod]
        public void TestGetRates()
        {
            var service = new TaxJarCalculator();
            var model = new TaxAddressModel
            {
                Zip = "30009",
                Street = "7221 Avlon Blvd",
                City = "Alpharetta",
                State = "GA",
                Country = "US"
            };
            var actual = service.GetRatesForLocation(model);

            Assert.AreEqual(0.0775m, actual.CombinedRate);
        }


        [TestMethod]
        public void TestGetOrderTaxes()
        {
            var service = new TaxJarCalculator();
            var fromAddress = new TaxAddressModel
            {
                Zip = "92093",
                Street = "9500 Gilman Drive",
                City = "La Jolla",
                State = "CA",
                Country = "US"
            };
            var toAddress = new TaxAddressModel
            {
                Zip = "90002",
                Street = "4627 Sunset Ave",
                City = "Los Angeles",
                State = "CA",
                Country = "US"
            };
            var model = new OrderTaxsModel
            {
                FromAddress = fromAddress,
                ToAddress = toAddress,
                Amount = 15.0m,
                Shipping = 1.5m
            };
            var actual = service.GetTaxsForOrder(model);


            Assert.AreEqual(1.43m, actual.AmountToCollect);
        }
    }
}
