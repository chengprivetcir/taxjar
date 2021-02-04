using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace TaxServices
{
    public class TaxJarCalculator : ITaxCalculator
    {
        private readonly string ApiKey = "5da2f821eee4035db4771edab942a4cc";
        public async Task<RateResult> GetRatesForLocationAsync(string zip)
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

                var httpResponse = await http.GetAsync("https://api.taxjar.com/v2/rates/"+ zip);

                var responseJsonString = await httpResponse.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RateResult>(responseJsonString);
            }
        }

        public async Task<TaxesResult> GetTaxsForOrderAsync(TaxesRequest request)
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

                var httpResponse = await http.PostAsync("https://api.taxjar.com/v2/taxes", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

                var responseJsonString = await httpResponse.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TaxesResult>(responseJsonString);
            }
        }
    }
}
