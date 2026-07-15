using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticComponentPartial  :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random Random = new Random();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7087/api/Statistic/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.v = values.CarCount;
                ViewBag.random1 = v1;

            }
            var responseMessage2 = await client.GetAsync("https://localhost:7087/api/Statistic/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int locationCountRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.locationCount = values2.LocationCount;
                ViewBag.locationCountRandom = locationCountRandom;

            }
            var responseMessage5 = await client.GetAsync("https://localhost:7087/api/Statistic/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int brandCountRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData5);
                ViewBag.brandCount = values5.BrandCount;
                ViewBag.brandCountRandom = brandCountRandom;

            }
            var responseMessage6 = await client.GetAsync("https://localhost:7087/api/Statistic/GetAvgPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int avgPriceRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData6);
                ViewBag.avgPrice = values6.AvgPriceForDaily.ToString("0.00");
                ViewBag.avgPriceRandom = avgPriceRandom;
            }
          
            return View();
        }
    }
}
