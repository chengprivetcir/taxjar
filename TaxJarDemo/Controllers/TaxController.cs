using System;
using Microsoft.AspNetCore.Mvc;
using Taxjar;
using TaxServices;
using TaxServices.Models;

namespace TaxJarDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxCalculator<RateResponseAttributes, TaxResponseAttributes> _TaxCalculator;
        private readonly ITaxCalculator<decimal, decimal> _FakeCalculator;
        public TaxController(ITaxCalculator<RateResponseAttributes, TaxResponseAttributes> TaxCalculator, ITaxCalculator<decimal, decimal> FakeCalculator)
        {
            _TaxCalculator = TaxCalculator;
            _FakeCalculator = FakeCalculator;
        }

        //https://localhost:44351/Tax/GetRates
//        {
//    "Zip":"05495-2086",
//    "Street":"312 Hurricane Lane",
//    "City":"Williston",
//    "State":"VT",
//    "Country":"US"
//}

        [Route("GetRates")]
        [HttpPost]
        public IActionResult GetRates(TaxAddressModel model)
        {
            try
            {
                var rates = _TaxCalculator.GetRatesForLocation(model);
                return Ok(rates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


//        https://localhost:44351/Tax/GetTaxes
//{
//  "fromAddress":  {
//    "zip": "92093",
//    "street": "9500 Gilman Drive",
//    "city": "La Jolla",
//    "state": "CA",
//    "country":"US"
//  },
//  "toAddress":  {
//    "zip": "90002",
//    "street": "4627 Sunset Ave",
//    "city": "Los Angeles",
//    "state": "CA",
//     "country":"US"
//  },
//  "amount": 15.0,
//  "shipping": 1.5
//}

        [Route("GetTaxes")]
        [HttpPost]
        public IActionResult GetTaxes(OrderTaxsModel model)
        {
            try
            {
                var rates = _TaxCalculator.GetTaxsForOrder(model);
                return Ok(rates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
