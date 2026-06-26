using CarBook.WebUI.Dtos.ContactDto;
using CarBook.WebUI.Dtos.FooterDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7211/api/Footer");     
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFooterAdressDto>>(jsonData);

            ViewBag.FooterAdress = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            createContactDto.SendDate = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            var content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7211/api/Contact",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Mesajınız başarıyla gönderildi!";
                return RedirectToAction("Index");
            }
            return View(createContactDto);
            
        }
    }
}
