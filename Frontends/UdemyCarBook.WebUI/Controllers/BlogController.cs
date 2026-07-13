using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CarPricingDtos;
using UdemyCarBook.Dto.CommentDtos;
using UdemyCarBook.Dto.LocationDtos;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace UdemyCarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7087/api/Blogs/GetAllBlogsWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogDto>>(jsonData); 

                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.BlogID = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($"https://localhost:7087/api/Comments/GetCommentCountByBlog?id={id}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.CommentCount = jsonData2;
            }
            else
            {
                ViewBag.CommentCount = 0;
            }



            return View();
        }  

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.BlogID = id;
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(int id, CreateCommentDto createCommentDto)
        {
            if (id > 0)
            {
                createCommentDto.BlogID = id;
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(new
            {
                createCommentDto.Name,
                createCommentDto.Description,
                createCommentDto.Email,
                createCommentDto.BlogID
            });
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7087/api/Comments/CreateCommentWithMediator", stringContent);

            return RedirectToAction("BlogDetail", new { id = createCommentDto.BlogID });
        }
    }
}
