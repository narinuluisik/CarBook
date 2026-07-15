using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial     :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardBlogListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7087/api/Blogs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogDto>>(jsonData, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
                return View(values);
            }

            return View();
        }

    }
}
