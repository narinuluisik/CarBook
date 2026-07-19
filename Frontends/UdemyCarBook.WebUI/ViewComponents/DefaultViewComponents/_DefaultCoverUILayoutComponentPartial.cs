using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text.Json;
using UdemyCarBook.Dto.BannerDtos;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var locationResponse = await client.GetAsync("https://localhost:7087/api/Locations");
            if (locationResponse.IsSuccessStatusCode)
            {
                var locationJson = await locationResponse.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<List<ResultLocationDto>>(locationJson) ?? new List<ResultLocationDto>();
                ViewBag.v = locations.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.LocationID.ToString()
                }).ToList();
            }
            else
            {
                ViewBag.v = new List<SelectListItem>();
            }

            var responseMessage = await client.GetAsync("https://localhost:7087/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = System.Text.Json.JsonSerializer.Deserialize<List<ResultBannerDto>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(values);
            }
            return View();
        }
    }
}