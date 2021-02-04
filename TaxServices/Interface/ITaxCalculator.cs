
using System.Threading.Tasks;

namespace TaxServices
{
    public interface ITaxCalculator
    {
        Task<RateResult> GetRatesForLocationAsync(string zip);

        Task<TaxesResult> GetTaxsForOrderAsync(TaxesRequest request);

    }
}
