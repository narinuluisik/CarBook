using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
    [AllowAnonymous]
    public class PagesController : Controller
    {
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
