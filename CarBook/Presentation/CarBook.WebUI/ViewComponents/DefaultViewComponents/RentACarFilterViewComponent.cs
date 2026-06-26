using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class RentACarFilterViewComponent:ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
