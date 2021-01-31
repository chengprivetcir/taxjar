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
