using System;
using Taxjar;
using TaxServices.Models;

namespace TaxServices
{
    public class TaxJarCalculator : ITaxCalculator<RateResponseAttributes, TaxResponseAttributes>
    {
        private readonly string ApiKey = "5da2f821eee4035db4771edab942a4cc";
        public RateResponseAttributes GetRatesForLocation(TaxAddressModel request)
        {
            try
            {
                var client = new TaxjarApi(ApiKey);
            
                if (request.Street == null || request.City == null || request.State == null || request.Country == null)
                {
                    var rates = client.RatesForLocation(request.Zip);
                    return rates;
                }
                else
                {
                    var rates = client.RatesForLocation(request.Zip, new
                    {
                        street = request.Street,
                        city = request.City,
                        state = request.State,
                        country = request.Country
                    });

                    return rates;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TaxResponseAttributes GetTaxsForOrder(OrderTaxsModel request)
        {
            try
            {
                var client = new TaxjarApi(ApiKey);

                var rates = client.TaxForOrder(new
                {
                    from_street = request.FromAddress.Street,
                    from_country = request.FromAddress.Country,
                    from_zip = request.FromAddress.Zip,
                    from_state = request.FromAddress.State,
                    from_city = request.FromAddress.City,

                    to_street = request.ToAddress.Street,
                    to_country = request.ToAddress.Country,
                    to_zip = request.ToAddress.Zip,
                    to_state = request.ToAddress.State,
                    to_city = request.ToAddress.City,

                    amount = request.Amount,
                    shipping = request.Shipping,
                });

                return rates;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
