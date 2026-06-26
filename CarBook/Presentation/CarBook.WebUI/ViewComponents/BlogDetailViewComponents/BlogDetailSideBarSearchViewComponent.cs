using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailSideBarSearchViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
