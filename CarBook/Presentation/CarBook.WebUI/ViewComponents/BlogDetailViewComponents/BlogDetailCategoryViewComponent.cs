using CarBook.WebUI.Dtos.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailCategoryViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogDetailCategoryViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Blog/GetBlogCountByCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBlogCountByCategory>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
