using CarBook.WebUI.Dtos.CarDto;
using CarBook.WebUI.Dtos.CarFeatureDto;
using CarBook.WebUI.Dtos.FeatureDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CarFeatureController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CarFeatureController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int carId)
        {
            ViewData["AddUrl"] = Url.Action("AddCarFeature", "CarFeature", new { area = "Admin", carId = carId });

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7211/api/CarFeature/GetByCarId/{carId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCarFeatureByCarIdDto>>(jsonData);
                return View(values ?? new List<GetCarFeatureByCarIdDto>());
            }
            return View(new List<GetCarFeatureByCarIdDto>());
        }

        [HttpGet]
        public async Task<IActionResult> AddCarFeature(int carId = 0)
        {
            var client = httpClientFactory.CreateClient();

            var carResponse = await client.GetAsync("https://localhost:7211/api/Car/GetCarWithBrand");
            var carJson = await carResponse.Content.ReadAsStringAsync();
            var cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(carJson) ?? new List<ResultCarWithBrandDto>();

            var featureResponse = await client.GetAsync("https://localhost:7211/api/Feature");
            var featureJson = await featureResponse.Content.ReadAsStringAsync();
            var features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(featureJson) ?? new List<ResultFeatureDto>();

            var selectedCar = cars.FirstOrDefault(x => x.Id == carId);
            ViewBag.SelectedCarId = carId;
            ViewBag.SelectedCarName = selectedCar != null
                ? selectedCar.BrandName + " " + selectedCar.Model
                : "Bilinmiyor";

            ViewBag.Features = features.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCarFeature(CreateCarFeatureDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7211/api/CarFeature", content);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "CarFeature", new { area = "Admin", carId = dto.CarId });

            var featureResponse = await client.GetAsync("https://localhost:7211/api/Feature");
            var features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(
                await featureResponse.Content.ReadAsStringAsync()) ?? new List<ResultFeatureDto>();

            var carResponse = await client.GetAsync("https://localhost:7211/api/Car/GetCarWithBrand");
            var cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(
                await carResponse.Content.ReadAsStringAsync()) ?? new List<ResultCarWithBrandDto>();

            var selectedCar = cars.FirstOrDefault(x => x.Id == dto.CarId);
            ViewBag.SelectedCarId = dto.CarId;
            ViewBag.SelectedCarName = selectedCar != null
                ? selectedCar.BrandName + " " + selectedCar.Model
                : "Bilinmiyor";

            ViewBag.Features = features.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleFeature([FromBody] UpdateCarFeatureDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7211/api/CarFeature/UpdateByCarId", content);

            if (responseMessage.IsSuccessStatusCode)
                return Ok();

            return BadRequest();
        }
    }
}