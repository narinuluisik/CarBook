using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7087/api/Blogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var blog = JsonConvert.DeserializeObject<GetBlogById>(jsonData);
                if (blog != null && blog.BlogID == 0)
                {
                    blog.BlogID = id;
                }

                var commentResponse = await client.GetAsync($"https://localhost:7087/api/Comments/GetCommentCountByBlog?id={id}");
                if (commentResponse.IsSuccessStatusCode)
                {
                    var commentCountData = await commentResponse.Content.ReadAsStringAsync();
                    var rawCount = (commentCountData ?? string.Empty).Trim().Trim('"');
                    ViewBag.CommentCount = int.TryParse(rawCount, out var count) ? count : 0;
                }
                else
                {
                    ViewBag.CommentCount = 0;
                }

                return View(blog);
            }

            return View();
        }
    }
}
