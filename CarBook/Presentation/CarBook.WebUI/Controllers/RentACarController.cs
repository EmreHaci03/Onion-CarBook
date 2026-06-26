using CarBook.WebUI.Dtos.RentACarDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class RentACarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> RentACarList(int pickUpLocationId, DateTime PickUpDate, DateTime DropOffDate)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7211/api/RentACar?locationId={pickUpLocationId}&avaliable=true&pickUpDate={PickUpDate:yyyy-MM-dd}&dropOffDate={DropOffDate:yyyy-MM-dd}"); var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetRentACarListDto>>(json);
            return View(values);
        }
    }
}
