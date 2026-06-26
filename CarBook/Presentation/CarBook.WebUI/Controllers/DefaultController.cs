using CarBook.WebUI.Dtos.LocationDto;
using CarBook.WebUI.Dtos.RentACarDto;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7211/api/Location");

            var json = await response.Content.ReadAsStringAsync();

            var locations = JsonConvert.DeserializeObject<List<ResultLocationDto>>(json);

            var model = new RentACarFilterViewModel
            {
                Locations = locations.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.LocationId.ToString()
                }).ToList()
            };
            return View(model);
        }
    }
}
