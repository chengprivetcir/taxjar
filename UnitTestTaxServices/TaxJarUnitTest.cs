using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TaxServices;


namespace UnitTestTaxServices
{
    [TestClass]
    public class TaxJarUnitTest
    {
        [TestMethod]
        public void TestGetRatesForZipCodeOnlyAsync()
        {
            var service = new TaxJarCalculator();

            var actual = service.GetRatesForLocationAsync("30009").GetAwaiter().GetResult();

            Assert.AreEqual("0.0775", actual.rate.combined_rate);
        }



        [TestMethod]
        public void TestGetOrderTaxes()
        {
            var service = new TaxJarCalculator();
            var request = new TaxesRequest
            {
                from_country = "US",
                from_state = "NJ",
                from_zip = "07001",
                to_country = "US",
                to_zip = "07446",
                to_state = "NJ",
                shipping = 1.5,
                amount = 16.50
            };


            var actual = service.GetTaxsForOrderAsync(request).GetAwaiter().GetResult();


            Assert.AreEqual(1.19, actual.tax.amount_to_collect);
        }
    }
}
