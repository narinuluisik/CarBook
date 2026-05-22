using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UdemyCarBook.Dto.ServiceDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
           var client = _httpClientFactory.CreateClient();
              var responseMessage = await client.GetAsync("https://localhost:7087/api/Services");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonSerializer.Deserialize<List<ResultServiceDto>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(values);
            }
            return View();
        }
    }
}
