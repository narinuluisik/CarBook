using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.LocationDtos;
using UdemyCarBook.Dto.ReservationDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.v3 = id;
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7087/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData) ?? new List<ResultLocationDto>();

            int? selectedLocationId = null;
            if (TempData["locationID"] != null && int.TryParse(TempData["locationID"]?.ToString(), out int locId))
            {
                selectedLocationId = locId;
            }

            List<SelectListItem> values2 = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationID.ToString(),
                Selected = selectedLocationId.HasValue && x.LocationID == selectedLocationId.Value
            }).ToList();

            ViewBag.v = values2;
        

            return View(new CreateReservationDto());
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7087/api/Reservation", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Rezervasyonunuz başarıyla alındı. En kısa sürede sizinle iletişime geçeceğiz.";
                return RedirectToAction("Index", "Default");
            }
            return View(createReservationDto);
        }
    }
}
