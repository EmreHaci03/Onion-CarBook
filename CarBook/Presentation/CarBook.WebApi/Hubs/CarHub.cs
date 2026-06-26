using Microsoft.AspNetCore.SignalR;

namespace CarBook.WebApi.Hubs
{
    public class CarHub:Hub
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task SendCarStats()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Statistic/GetAllStatistic");
            var value = await responseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCarStats", value);
        }
    }
}
