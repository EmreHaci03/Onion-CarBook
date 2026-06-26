using CarBook.WebUI.Dtos.ReservationDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> ReservationList()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7211/api/Reservation");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(json);
                return View(values);
            }
            return View(new List<ResultReservationDto>());
        }
    }
}
