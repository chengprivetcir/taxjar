namespace TaxServices.Models
{
    public class OrderTaxsModel
    {
        public TaxAddressModel FromAddress { get; set; }

        public TaxAddressModel ToAddress { get; set; }

        public decimal Amount { get; set; }

        public decimal Shipping { get; set; }
    }
}
