using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var currencies = new List<string> { "usd", "eur", "gbp", "usd" };
            var targets = new List<string> { "try", "try", "try", "eur" };

            for (int i = 0; i < currencies.Count; i++)
            {
                await GetCurrencyRate(currencies[i], targets[i]);
            }

            return View();
        }

        private async Task GetCurrencyRate(string currency, string target)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://currency-exchange.p.rapidapi.com/exchange?from={currency}&to={target}&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "7628cfdf4fmshd27344ca1806a9fp13a307jsn63d31a0ad40c" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                double rate = double.Parse(body);
                ViewData[$"{currency.ToUpper()}To{target.ToUpper()}"] = rate.ToString("F3");
            }
        }

    }
}
