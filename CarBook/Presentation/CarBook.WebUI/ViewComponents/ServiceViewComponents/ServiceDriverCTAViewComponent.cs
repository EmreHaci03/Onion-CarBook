using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ServiceViewComponents
{
    public class ServiceDriverCTAViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
