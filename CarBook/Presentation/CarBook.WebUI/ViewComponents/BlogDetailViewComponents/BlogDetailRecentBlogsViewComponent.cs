using CarBook.WebUI.Dtos.BlogDto;
using CarBook.WebUI.Dtos.CommentDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailRecentBlogsViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogDetailRecentBlogsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7211/api/Blog/GetLast3blogsWithAuthor");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetLast3BlogsWithAuthorDto>>(jsonData);

                var commentCounts = new Dictionary<int, int>();

                if (values != null)
                {
                    foreach (var blog in values)
                    {
                        var commentResponse = await client.GetAsync($"https://localhost:7211/api/Comment/CommentCount/{blog.Id}");
                        if (commentResponse.IsSuccessStatusCode)
                        {
                            var commentJson = await commentResponse.Content.ReadAsStringAsync();
                            var commentResult = JsonConvert.DeserializeObject<List<GetCommentCountByBlogIdDto>>(commentJson);
                            commentCounts[blog.Id] = commentResult?.FirstOrDefault()?.CommentCount ?? 0;
                        }
                    }
                }

                ViewBag.CommentCounts = commentCounts;
                return View(values);
            }

            ViewBag.CommentCounts = new Dictionary<int, int>();
            return View(new List<GetLast3BlogsWithAuthorDto>());
        }
    }
}
