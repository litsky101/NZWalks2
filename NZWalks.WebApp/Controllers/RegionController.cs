using Microsoft.AspNetCore.Mvc;

namespace NZWalks.WebApp.Controllers
{
    public class RegionController : Controller
    {
        private readonly IHttpClientFactory clientFactor;

        public RegionController(IHttpClientFactory _clientFactor)
        {
            clientFactor = _clientFactor;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = clientFactor.CreateClient();

                var httpResponse = await client.GetAsync("https://localhost:7220/api/regions");

                httpResponse.EnsureSuccessStatusCode();

                var responseBody = await httpResponse.Content.ReadAsStringAsync();

                ViewBag.Response = responseBody;
            }
            catch (Exception ex)
            {

                
            }

            return View();
        }
    }
}
