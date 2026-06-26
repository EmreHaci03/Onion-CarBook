using CarBook.WebUI.Dtos.GetAllStatisticsDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultStatisticViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DefaultStatisticViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Statistic/GetAllStatistic");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAllStatisticDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
