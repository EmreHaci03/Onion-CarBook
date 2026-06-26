using CarBook.WebUI.Dtos.CarDescriptionDto;
using CarBook.WebUI.Dtos.CarDto;
using CarBook.WebUI.Dtos.ReviewDto;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Car/GetCarsWithPricings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.CarId = id;
            var client = _httpClientFactory.CreateClient();

            // Araç detayı
            var carResponse = await client.GetAsync($"https://localhost:7211/api/Car/GetCarWithBrandById/{id}");
            if (!carResponse.IsSuccessStatusCode)
                return View(new CarDetailViewModel());

            var jsonData = await carResponse.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<CarDetailViewModel>(jsonData);

            // Description — CarId ile çek
            var descResponse = await client.GetAsync($"https://localhost:7211/api/CarDescription/{id}");
            if (descResponse.IsSuccessStatusCode)
            {
                var descJson = await descResponse.Content.ReadAsStringAsync();
                var desc = JsonConvert.DeserializeObject<GetCarDescriptionDto>(descJson);
                values.DetailDescription = desc?.DetailDescription;
            }

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(CreateReviewDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessge = await client.PostAsync("https://localhost:7211/api/Review",content);
            if (responseMessge.IsSuccessStatusCode)
                return RedirectToAction("CarDetail",new { id = dto.CarId});
            return View();
        }

    }
}
