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
        //Can switch the calculator service based upon requirements
        private readonly ITaxCalculator<RateResponseAttributes, TaxResponseAttributes, TaxAddressModel, OrderTaxsModel> _TaxCalculator;
        private readonly ITaxCalculator<decimal, decimal, string, string> _FakeCalculator;
        public TaxController(ITaxCalculator<RateResponseAttributes, TaxResponseAttributes, TaxAddressModel, OrderTaxsModel> TaxCalculator, ITaxCalculator<decimal, decimal, string, string> FakeCalculator)
        {
            _TaxCalculator = TaxCalculator;
            _FakeCalculator = FakeCalculator;
        }

        public IActionResult index()
        {
            return Ok("Get Fake Rate:" + _FakeCalculator.GetRatesForLocation("") + " Get Fake Tax " + _FakeCalculator.GetTaxsForOrder(""));
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
