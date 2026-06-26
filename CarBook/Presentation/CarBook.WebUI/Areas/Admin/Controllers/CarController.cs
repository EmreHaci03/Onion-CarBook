using CarBook.WebUI.Dtos.BrandDto;
using CarBook.WebUI.Dtos.CarDto;
using CarBook.WebUI.Dtos.ReviewDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Car/GetCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(values ?? new List<ResultCarWithBrandDto>());
            }
            return View(new List<ResultCarWithBrandDto>());
        }

       

        [HttpGet]
        public async Task<IActionResult> AddCar()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7211/api/Brand");
            var json = await response.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(json);
            ViewBag.Brands = brands ?? new List<ResultBrandDto>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CreateCarDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7211/api/Car", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            var brandResponse = await client.GetAsync("https://localhost:7211/api/Brand");
            var brandJson = await brandResponse.Content.ReadAsStringAsync();
            ViewBag.Brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJson) ?? new List<ResultBrandDto>();
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7211/api/Car/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = httpClientFactory.CreateClient();

            var brandResponse = await client.GetAsync("https://localhost:7211/api/Brand");
            var brandJson = await brandResponse.Content.ReadAsStringAsync();
            ViewBag.Brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJson) ?? new List<ResultBrandDto>();

            var responseMessage = await client.GetAsync($"https://localhost:7211/api/Car/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7211/api/Car", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            var brandResponse = await client.GetAsync("https://localhost:7211/api/Brand");
            var brandJson = await brandResponse.Content.ReadAsStringAsync();
            ViewBag.Brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJson) ?? new List<ResultBrandDto>();
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> GetReviewByCarId(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7211/api/Review/GetReviewsByCarId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetReviewByCarIdDto>>(jsonData);
                return View(values ?? new List<GetReviewByCarIdDto>());
            }
            return View();
        }

    }
}