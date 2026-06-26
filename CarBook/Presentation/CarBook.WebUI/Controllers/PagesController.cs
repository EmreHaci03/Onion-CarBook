using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Page404()
        {
            return View();
        }

        public IActionResult Page403()
        {
            return View();
        }
    }
}
