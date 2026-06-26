using CarBook.WebUI.Dtos.FooterDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterAddressViewComponents
{
    public class FooterAddressViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterAddressViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Footer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAdressDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
