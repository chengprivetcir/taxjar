using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxServices;


namespace TaxJarDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        //Can switch the calculator service based upon requirements
        private readonly ITaxCalculator _TaxCalculator;
 
        public TaxController(ITaxCalculator TaxCalculator)
        {
            _TaxCalculator = TaxCalculator;
   
        }

        public IActionResult index()
        {
            return Ok("API Site is running");
        }

        [Route("GetRates")]
        public async Task<IActionResult> GetRatesAsync([FromQuery] string Zip)
        {
            try
            {
                var rates =  await _TaxCalculator.GetRatesForLocationAsync(Zip);
                return Ok(rates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetTaxes")]
        [HttpPost]
        public async Task<IActionResult> GetTaxesAsync([FromBody] TaxesRequest model)
        {
            try
            {
                var rates = await _TaxCalculator.GetTaxsForOrderAsync(model);
                return Ok(rates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
