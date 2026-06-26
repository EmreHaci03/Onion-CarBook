using CarBook.WebUI.Dtos.AuthorDto;
using CarBook.WebUI.Dtos.BlogDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailAuthorAboutViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogDetailAuthorAboutViewComponent(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int authorId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7211/api/Author/{authorId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAuthorByIdDto>(jsonData);
                return View(values);
            }
            return View(new GetAuthorByIdDto());       
        }
    }
}
