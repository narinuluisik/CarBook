using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.RentACarDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            // Eğer URL'den (Route) id parametresi gelmediyse, TempData'ya son bir şans tanıyoruz
            if (id == 0 && TempData["locationID"] != null)
            {
                int.TryParse(TempData["locationID"].ToString(), out id);
            }

            // ID hala 0 ise ana sayfaya geri gönderiyoruz (Çünkü 0 id'li lokasyon olamaz)
            if (id == 0)
            {
                return RedirectToAction("Index", "Default");
            }

            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Uygun Araçları Listele";

            ViewBag.locationID = id;
            TempData["locationID"] = id;

            var client = _httpClientFactory.CreateClient();
            string apiUrl = $"https://localhost:7087/api/RentACars?locationID={id}&available=true";
            var responseMessage = await client.GetAsync(apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);

                return View(values ?? new List<FilterRentACarDto>());
            }

            return View(new List<FilterRentACarDto>());
        }
    }
}
