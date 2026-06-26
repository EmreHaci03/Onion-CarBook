using CarBook.WebUI.Dtos.CarDto;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CarPricingController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 10;

            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7211/api/Car/GetCarsWithPricings");
            var json = await response.Content.ReadAsStringAsync();
            var allItems = JsonConvert.DeserializeObject<List<ResultCarWithPricingDto>>(json);

            var totalPages = (int)Math.Ceiling(allItems.Count / (double)pageSize);
            var pagedItems = allItems
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new PagedCarPricingViewModel
            {
                Items = pagedItems,
                PageNumber = page,
                TotalPages = totalPages
            };

            return View(model);
        }
    }
}
