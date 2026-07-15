using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CarDescriptionDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarDesriptionByCarIdComponentPartial       : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailCarDesriptionByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7087/api/CarDescription?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarDesriptionByCarIdDto>(jsonData);
                return View(values ?? new ResultCarDesriptionByCarIdDto());
            }
            return View(new ResultCarDesriptionByCarIdDto());
        }
    }
}
