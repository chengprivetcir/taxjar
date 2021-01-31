using System;
using System.Collections.Generic;
using System.Text;
using TaxServices.Models;

namespace TaxServices
{
    public class FakeCalculator : ITaxCalculator<decimal, decimal>
    {
        public decimal GetRatesForLocation(TaxAddressModel request)
        {
            return 0.0m;
        }

        public decimal GetTaxsForOrder(OrderTaxsModel request)
        {
            return 0.2m;
        }
    }
}
