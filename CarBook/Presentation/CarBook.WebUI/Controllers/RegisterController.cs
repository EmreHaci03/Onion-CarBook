using CarBook.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7211/api/Register", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Login");

            return View(dto);
        }
    }
}
