using CarBook.WebUI.Dtos.CarDto;
using CarBook.WebUI.Dtos.ReviewDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ReviewController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ReviewController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddReview()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7211/api/Car/GetCarWithBrand");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(json);
                ViewBag.Cars = cars ?? new List<ResultCarWithBrandDto>();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(CreateReviewDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7211/api/Review", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            var carResponse = await client.GetAsync("https://localhost:7211/api/Car/GetCarWithBrand");
            if (carResponse.IsSuccessStatusCode)
            {
                var carJson = await carResponse.Content.ReadAsStringAsync();
                ViewBag.Cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(carJson);
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var client = httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7211/api/Review/{id}");
            return RedirectToAction("Index");
        }
    }
}