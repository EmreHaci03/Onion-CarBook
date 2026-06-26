using CarBook.WebUI.Dtos.CarDto;
using CarBook.WebUI.Dtos.CarPricingDto;
using CarBook.WebUI.Dtos.PricingDto;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CarPricingController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]

        public async Task<IActionResult> CarPricing()
        {
            var client = httpClientFactory.CreateClient();

            var pricingResponse = await client.GetAsync("https://localhost:7211/api/CarPricing");
            if (pricingResponse.IsSuccessStatusCode)
            {
                var json = await pricingResponse.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<ResultCarPricingDto>>(json);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCarPricing()
        {
            var client = httpClientFactory.CreateClient();

            var carResponse = await client.GetAsync("https://localhost:7211/api/Car/GetCarWithBrand");
            var cars = new List<ResultCarWithBrandDto>();

            if (carResponse.IsSuccessStatusCode)
            {
                var json = await carResponse.Content.ReadAsStringAsync();
                cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(json);
            }

            var pricingResponse = await client.GetAsync("https://localhost:7211/api/Pricing");
            var pricings = new List<ResultPricingDto>();

            if (pricingResponse.IsSuccessStatusCode)
            {
                var json = await pricingResponse.Content.ReadAsStringAsync();
                pricings = JsonConvert.DeserializeObject<List<ResultPricingDto>>(json);
            }

            ViewBag.Cars = cars.Select(x => new SelectListItem
            {
                Text = x.BrandName + " " + x.Model,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.Pricings = pricings.Select(x => new SelectListItem
            {
                Text = x.Name,  
                Value = x.Id.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCarPricing(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7211/api/CarPricing/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("CarPricing", "CarPricing");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCarPricing(CreateCarPricingDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7211/api/CarPricing", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("CarPricing", "CarPricing");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCarPricing(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7211/api/CarPricing/{id}");
            if (response.IsSuccessStatusCode) {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarPricingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(dto);
            var content=new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7211/api/CarPricing",content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("CarPricing");

            return View(dto);
        }
    }
}

