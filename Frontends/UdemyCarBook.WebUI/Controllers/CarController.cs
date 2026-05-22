using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UdemyCarBook.Dto.CarDtos;

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
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7087/api/Cars/GetCarWithBrand");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonSerializer.Deserialize<List<ResultCarDto>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(values);
            }
            return View();
        }
    }
}
