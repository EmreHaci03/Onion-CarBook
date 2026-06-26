using CarBook.WebUI.Dtos.AuthorDto;
using CarBook.WebUI.Dtos.BlogCategoryDto;
using CarBook.WebUI.Dtos.BlogDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        private async Task FillDropdowns(IHttpClientFactory factory, int selectedAuthorId = 0, int selectedCategoryId = 0)
        {
            var client = factory.CreateClient();

            var authorResponse = await client.GetAsync("https://localhost:7211/api/Author");
            var authors = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(
                await authorResponse.Content.ReadAsStringAsync()) ?? new List<ResultAuthorDto>();

            var categoryResponse = await client.GetAsync("https://localhost:7211/api/Category");
            var categories = JsonConvert.DeserializeObject<List<ResultBlogCategoryDto>>(
                await categoryResponse.Content.ReadAsStringAsync()) ?? new List<ResultBlogCategoryDto>();

            ViewBag.Authors = authors.Select(x => new SelectListItem
            {
                Text = x.AuthorName,
                Value = x.Id.ToString(),
                Selected = x.Id == selectedAuthorId
            }).ToList();

            ViewBag.BlogCategories = categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = x.Id == selectedCategoryId
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Blog");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
                return View(values ?? new List<ResultBlogDto>());
            }
            return View(new List<ResultBlogDto>());
        }

        [HttpGet]
        public async Task<IActionResult> AdminAddBlog()
        {
            await FillDropdowns(httpClientFactory);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminAddBlog(CreateBlogDto dto)
        {
            dto.CreateDate = DateTime.Now;
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7211/api/Blog", content);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            await FillDropdowns(httpClientFactory, dto.AuthorId, dto.BlogCategoryId);
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> AdminDeleteBlog(int id)
        {
            var client = httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7211/api/Blog/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AdminUpdateBlog(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7211/api/Blog/{id}");

            var values = new UpdateBlogDto();
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData) ?? new UpdateBlogDto();
            }

            await FillDropdowns(httpClientFactory, values.AuthorId, values.BlogCategoryId);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AdminUpdateBlog(UpdateBlogDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7211/api/Blog", content);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            await FillDropdowns(httpClientFactory, dto.AuthorId, dto.BlogCategoryId);
            return View(dto);
        }
    }
}