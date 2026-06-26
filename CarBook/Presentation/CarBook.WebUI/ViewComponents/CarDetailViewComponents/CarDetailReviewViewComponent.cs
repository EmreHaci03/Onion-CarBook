using CarBook.WebUI.Dtos.ReviewDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class CarDetailReviewViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CarDetailReviewViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7211/api/Review/GetReviewsByCarId/{carId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReviewDto>>(json);
                return View(values ?? new List<ResultReviewDto>());
            }
            return View(new List<ResultReviewDto>());
        }
    }
}