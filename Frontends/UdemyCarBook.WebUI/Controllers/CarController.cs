using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.CarPricingDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult>Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Araçlarınızı Seçiniz";
            var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7087/api/CarPricing");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonSerializer.Deserialize<List<ResultCarPricingDto>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(values);
            }
            return View();
        }
    }
}
