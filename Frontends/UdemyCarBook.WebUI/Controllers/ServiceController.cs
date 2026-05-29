using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UdemyCarBook.Dto.ServiceDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
      
        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetlerimiz";
            return View();
        }
    }
}
