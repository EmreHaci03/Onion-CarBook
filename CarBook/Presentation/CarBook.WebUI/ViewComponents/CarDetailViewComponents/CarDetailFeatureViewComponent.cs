using CarBook.WebUI.Dtos.CarDto;
using CarBook.WebUI.Dtos.CarFeatureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class CarDetailFeatureViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarDetailFeatureViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7211/api/CarFeature/GetByCarId/{carId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View(new List<GetCarFeatureByCarIdDto>());
        }
    }
}
