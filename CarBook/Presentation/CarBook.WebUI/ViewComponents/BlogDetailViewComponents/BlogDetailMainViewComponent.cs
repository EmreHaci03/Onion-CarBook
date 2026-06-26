using CarBook.WebUI.Dtos.BlogDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailMainViewComponent:ViewComponent
    {
      
        public async Task<IViewComponentResult> InvokeAsync(GetBlogByIdDto model)
        { 
            return View(model);
        }
    }
}
