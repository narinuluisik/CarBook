using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UdemyCarBook.Dto.FooterAddressDto;
using UdemyCarBook.Dto.TestimonialDtos;

namespace UdemyCarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7087/api/FooterAdresses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonSerializer.Deserialize<List<ResultFooterAddressDto>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(values);
            }

            return View();
        }
    }
}
