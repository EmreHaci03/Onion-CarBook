using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class AboutDriverCTAViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
