using CarBook.WebUI.Dtos.CommentDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogCommentsViewComponent
{
    public class BlogCommentsViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogCommentsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7211/api/Comment/GetCommentsByBlogId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCommentByBlogIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
