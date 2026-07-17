using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var responseMessage = await client.GetAsync("https://localhost:7087/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.LocationID.ToString()
                                                }).ToList();

                ViewBag.v = values2;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string LocationID)
        {
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;

            // Büyük harfli LocationID parametresini güvenle parse edip yönlendiriyoruz
            if (!string.IsNullOrEmpty(LocationID) && int.TryParse(LocationID, out int parsedId))
            {
                return RedirectToAction("Index", "RentACarList", new { id = parsedId });
            }

            return RedirectToAction("Index");
        }
    }
}
