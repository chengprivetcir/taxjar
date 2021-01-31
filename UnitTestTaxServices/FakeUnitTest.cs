using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxServices;

namespace UnitTestTaxServices
{
    [TestClass]
    public class FakeUnitTest
    {
        [TestMethod]
        public void TestFakeGetRates()
        {

            var service = new FakeTaxCalculator();
            
            var actual = service.GetRatesForLocation("");

            Assert.AreEqual(0.0m, actual);
        }

        [TestMethod]
        public void TestFakeGetTaxes()
        {

            var service = new FakeTaxCalculator();

            var actual = service.GetTaxsForOrder("");

            Assert.AreEqual(0.2m, actual);
        }
    }
}
