using CarBook.WebUI.Dtos.CarDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultLast5CarsWithBrandsViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultLast5CarsWithBrandsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Car/GetLast5CarsWithBrands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
