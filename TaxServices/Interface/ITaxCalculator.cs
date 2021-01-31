
namespace TaxServices
{
    public interface ITaxCalculator<T1, T2, T3, T4>
    {
        T1 GetRatesForLocation(T3 request);

        T2 GetTaxsForOrder(T4 request);

    }
}
