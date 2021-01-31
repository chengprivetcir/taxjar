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
            var model = new TaxAddressModel();
            model.Zip = "30009";

            var actual = service.GetRatesForLocation(model);


            Assert.AreEqual(0.0775m, actual.CombinedRate);
        }

        [TestMethod]
        public void TestGetRates()
        {
            var service = new TaxJarCalculator();
            var model = new TaxAddressModel();
            model.Zip = "30009";
            model.Street = "7221 Avlon Blvd";
            model.City = "Alpharetta";
            model.State = "GA";
            model.Country = "US";

            var actual = service.GetRatesForLocation(model);


            Assert.AreEqual(0.0775m, actual.CombinedRate);
        }


        [TestMethod]
        public void TestGetOrderTaxes()
        {
            var service = new TaxJarCalculator();

            var model = new OrderTaxsModel();

            var fromAddress = new TaxAddressModel();
            fromAddress.Zip = "92093";
            fromAddress.Street = "9500 Gilman Drive";
            fromAddress.City = "La Jolla";
            fromAddress.State = "CA";
            fromAddress.Country = "US";

            var toAddress = new TaxAddressModel();
            toAddress.Zip = "90002";
            toAddress.Street = "4627 Sunset Ave";
            toAddress.City = "Los Angeles";
            toAddress.State = "CA";
            toAddress.Country = "US";

            model.FromAddress = fromAddress;
            model.ToAddress = toAddress;
            model.Amount = 15.0m;
            model.Shipping = 1.5m;

            var actual = service.GetTaxsForOrder(model);


            Assert.AreEqual(1.43m, actual.AmountToCollect);
        }
    }
}
