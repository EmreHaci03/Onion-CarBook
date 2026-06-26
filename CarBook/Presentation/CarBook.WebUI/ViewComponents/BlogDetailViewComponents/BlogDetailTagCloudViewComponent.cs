using CarBook.WebUI.Dtos.TagCloudDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailTagCloudViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogDetailTagCloudViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7211/api/TagCloud/GetTagCloudByBlogId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetByBlogIdTagCloudDto>>(jsonData);
                return View(values);
            }
            return View(new GetByBlogIdTagCloudDto());
        }
    }
}
