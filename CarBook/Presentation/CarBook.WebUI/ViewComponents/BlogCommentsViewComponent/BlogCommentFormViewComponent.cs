using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogCommentsViewComponent
{
    public class BlogCommentFormViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.BlogId = id;
            return View();
        }
    }
}
