using System;
using System.Collections.Generic;
using System.Text;
using TaxServices.Models;

namespace TaxServices
{
    public class FakeCalculator : ITaxCalculator<decimal, decimal, string, string>
    {
        public decimal GetRatesForLocation(string request)
        {
            return 0.0m;
        }

        public decimal GetTaxsForOrder(string request)
        {
            return 0.2m;
        }
    }
}
