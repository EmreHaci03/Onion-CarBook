using CarBook.WebUI.Dtos.BlogDto;
using CarBook.WebUI.Dtos.GetAllStatisticsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Statistic
            var response = await client.GetAsync("https://localhost:7211/api/Statistic/GetAllStatistic");
            GetAllStatisticDto values = new GetAllStatisticDto();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<GetAllStatisticDto>(json) ?? new GetAllStatisticDto();
            }

            
            var weatherClient = _httpClientFactory.CreateClient();
            weatherClient.DefaultRequestHeaders.Add("x-rapidapi-key", "a693dc5d65msh7377e4f54ffa739p1b5271jsn14d5fdf07de3");
            weatherClient.DefaultRequestHeaders.Add("x-rapidapi-host", "open-weather13.p.rapidapi.com");
            var responseWeather = await weatherClient.GetAsync("https://open-weather13.p.rapidapi.com/city?city=Istanbul&lang=TR");
            if (responseWeather.IsSuccessStatusCode)
            {
                var weatherJson = await responseWeather.Content.ReadAsStringAsync();
                var weather = JsonConvert.DeserializeObject<dynamic>(weatherJson);
                ViewBag.Description = weather["weather"][0]["description"];
                string iconCode = (string)weather["weather"][0]["icon"];
                ViewBag.Icon = iconCode switch
                {
                    "01d" => "☀️",
                    "01n" => "🌙",
                    "02d" or "02n" => "⛅",
                    "03d" or "03n" => "🌥️",
                    "04d" or "04n" => "☁️",
                    "09d" or "09n" => "🌧️",
                    "10d" or "10n" => "🌦️",
                    "11d" or "11n" => "⛈️",
                    "13d" or "13n" => "❄️",
                    "50d" or "50n" => "🌫️",
                    _ => "⛅"
                };

                var temp = (double)weather["main"]["temp"];
                ViewBag.Temp = Math.Round((temp - 32) * 5 / 9, 1);


                ViewBag.Humidity =weather["main"]["humidity"];
                ViewBag.WindSpeed = weather["wind"]["speed"];
                ViewBag.CityName = weather["name"];

            }

            var blogResponse = await client.GetAsync("https://localhost:7211/api/Blog/GetLast5blogsWithAuthor");
            if (blogResponse.IsSuccessStatusCode)
            {
                var blogJson = await blogResponse.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<List<ResultBlogDto>>(blogJson);
                ViewBag.Last5Blogs = blogs;
            }


            return View(values);
        }
    }
}
