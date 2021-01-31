using System;
using System.Collections.Generic;
using System.Text;
using TaxServices.Models;

namespace TaxServices
{
    public interface ITaxCalculator<T1, T2>
    {
        T1 GetRatesForLocation(TaxAddressModel request);

        T2 GetTaxsForOrder(OrderTaxsModel request);

    }
}
