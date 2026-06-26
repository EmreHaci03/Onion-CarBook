using CarBook.WebUI.Dtos.GetAllStatisticsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Statistic/GetAllStatistic");
            var json = await responseMessage.Content.ReadAsStringAsync();

            var stats = JsonSerializer.Deserialize<GetAllStatisticDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            ViewBag.CarCount = stats.CarCount;
            ViewBag.LastBlogTitle = stats.LastBlogName;
            ViewBag.LastBlogAuthor = stats.LastBlogAuthor;
            ViewBag.OldestCarBrand = stats.OldestCarBrandName;
            ViewBag.OldestCarModel = stats.OldestCarModel;
            ViewBag.NewestCarBrand = stats.NewestCarBrandName;
            ViewBag.NewestCarModel = stats.NewestCarModel;
            ViewBag.MostCommentedBlogName = stats.MostCommentedBlogTitle;
            ViewBag.MostCommentCount = stats.MostCommentedBlogCommentCount;
            ViewBag.MostCarBrandName = stats.MostCarBrandName;
            ViewBag.MostCarCount = stats.MostCarCount;
            ViewBag.HighestMileageCar = stats.HighestCarMileage;
            ViewBag.MileageValue = stats.MileageValue;
            ViewBag.MostUsedFuelType = stats.MostUsedFuelType;
            ViewBag.FuelTypeCount = stats.FuelTypeCount;
            ViewBag.CheapestCarName = stats.CarNameWithBrand;
            ViewBag.CheapestCarPrice = stats.CheapestCarPriceDay;

            ViewBag.HighestPriceCarName = stats.HighestPriceCar;
            ViewBag.HighestCarPriceDay = stats.HighestCarDailyPrice;

            ViewBag.TotalReservation = stats.GetReservationCount;
            ViewBag.CarFuelType = stats.FuelTypeCount;
            return View(stats);
        }
    }
}
