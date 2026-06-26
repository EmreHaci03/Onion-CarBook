using CarBook.WebUI.Dtos.CarDescriptionDto;
using CarBook.WebUI.Dtos.CarDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CarDescriptionController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CarDescriptionController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7211/api/CarDescription");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCarDescriptionDto>>(json);
                return View(values ?? new List<GetCarDescriptionDto>());
            }
            return View(new List<GetCarDescriptionDto>());
        }

        [HttpGet]
        public async Task<IActionResult> AddDescription()
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
        public async Task<IActionResult> AddDescription(CreateCarDescriptionDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7211/api/CarDescription", content);
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
        public async Task<IActionResult> DeleteDescription(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7211/api/CarDescription/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDescription(int id)
        {
            var client = httpClientFactory.CreateClient();

            var descResponse = await client.GetAsync($"https://localhost:7211/api/CarDescription/GetById/{id}");

            if (!descResponse.IsSuccessStatusCode)
                return RedirectToAction("Index");

            var descJson = await descResponse.Content.ReadAsStringAsync();
            var desc = JsonConvert.DeserializeObject<GetCarDescriptionDto>(descJson);

            var carResponse = await client.GetAsync("https://localhost:7211/api/Car/GetCarWithBrand");
            if (carResponse.IsSuccessStatusCode)
            {
                var carJson = await carResponse.Content.ReadAsStringAsync();
                ViewBag.Cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(carJson);
            }

            return View(new UpdateCarDescriptionDto
            {
                Id = desc.Id,
                CarId = desc.CarId,
                DetailDescription = desc.DetailDescription
            });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDescription(UpdateCarDescriptionDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7211/api/CarDescription", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(dto);
        }

       
    }
}