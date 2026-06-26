using CarBook.WebUI.Dtos.PricingDto;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public PricingController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Pricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddPricing()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPricing(CreatePricingDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7211/api/Pricing", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePricing(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7211/api/Pricing/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePricing(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7211/api/Pricing/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePricingDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData =JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7211/api/Pricing", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
    }
}
