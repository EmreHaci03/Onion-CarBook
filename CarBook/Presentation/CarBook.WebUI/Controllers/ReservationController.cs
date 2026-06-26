using CarBook.WebUI.Dtos.CarDto;
using CarBook.WebUI.Dtos.CarPricingDto;
using CarBook.WebUI.Dtos.LocationDto;
using CarBook.WebUI.Dtos.ReservationDto;
using CarBook.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using Newtonsoft.Json;
using MailKit.Net.Smtp;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration _configuration;

        public ReservationController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = httpClientFactory.CreateClient();

            // Lokasyonlar
            var locationResponse = await client.GetAsync("https://localhost:7211/api/Location");
            var locationJson = await locationResponse.Content.ReadAsStringAsync();
            var locations = JsonConvert.DeserializeObject<List<ResultLocationDto>>(locationJson);

            var locationItems = locations.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString()
            }).ToList();

            ViewBag.PickUpLocation = locationItems;
            ViewBag.DropOffLocation = locationItems;

            // Araç bilgisi
            var carResponse = await client.GetAsync($"https://localhost:7211/api/Car/GetCarWithBrandById/{id}");
            var carJson = await carResponse.Content.ReadAsStringAsync();
            var car = JsonConvert.DeserializeObject<GetCarWithBrandByIdDto>(carJson);

            TempData["CarId"] = id;
            TempData["CarName"] = car.BrandName + " " + car.Model;

            // Fiyatlar
            var priceResponse = await client.GetAsync($"https://localhost:7211/api/CarPricing/ByCarId/{id}");
            var priceJson = await priceResponse.Content.ReadAsStringAsync();
            var prices = JsonConvert.DeserializeObject<List<ResultCarPricingDto>>(priceJson);
            ViewBag.Prices = prices;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] CreateReservationDto dto)
        {
            if (dto == null)
                return BadRequest("DTO null geldi");

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7211/api/Reservation", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                SendReservationMail(dto);
                return Ok();
            }

            return BadRequest(responseBody);
        }

        private void SendReservationMail(CreateReservationDto dto)
        {
            try
            {
                var from = _configuration["MailSettings:From"];
                var fromName = _configuration["MailSettings:FromName"];
                var host = _configuration["MailSettings:Host"];
                var port = int.Parse(_configuration["MailSettings:Port"]!);
                var password = _configuration["MailSettings:Password"];

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromName, from));
                message.To.Add(new MailboxAddress($"{dto.ReservationName} {dto.ReservationSurname}", dto.Email));
                message.Subject = "CarBook — Rezervasyonunuz Alındı";

                var body = $@"
        <div style='font-family:Arial,sans-serif; max-width:600px; margin:0 auto;'>
            <div style='background:#1d2127; padding:28px; border-radius:12px 12px 0 0; text-align:center;'>
                <h1 style='color:#fbb710; margin:0; font-size:24px;'>Araç<span style='color:#fff;'>Kirala</span></h1>
            </div>
            <div style='background:#f8fafc; padding:32px; border:1px solid #e2e8f0;'>
                <h2 style='color:#0f172a; font-size:18px;'>Merhaba {dto.ReservationName} {dto.ReservationSurname},</h2>
                <p style='color:#64748b;'>Rezervasyonunuz başarıyla alınmıştır. Detaylar aşağıdadır:</p>

                <div style='background:#fff; border:1px solid #e2e8f0; border-radius:10px; padding:20px; margin:20px 0;'>
                    <table style='width:100%; font-size:14px;'>
                        <tr><td style='color:#94a3b8; padding:8px 0;'>Ad Soyad</td><td style='font-weight:600; color:#0f172a;'>{dto.ReservationName} {dto.ReservationSurname}</td></tr>
                        <tr><td style='color:#94a3b8; padding:8px 0;'>E-posta</td><td style='font-weight:600; color:#0f172a;'>{dto.Email}</td></tr>
                        <tr><td style='color:#94a3b8; padding:8px 0;'>Telefon</td><td style='font-weight:600; color:#0f172a;'>{dto.PhoneNumber}</td></tr>
                        <tr><td style='color:#94a3b8; padding:8px 0;'>Alış Tarihi</td><td style='font-weight:600; color:#0f172a;'>{dto.PickUpDate?.ToString("dd MMM yyyy")}</td></tr>
                        <tr><td style='color:#94a3b8; padding:8px 0;'>Bırakış Tarihi</td><td style='font-weight:600; color:#0f172a;'>{dto.DropOffDate?.ToString("dd MMM yyyy")}</td></tr>
                        <tr><td style='color:#94a3b8; padding:8px 0;'>Tutar</td><td style='font-weight:700; color:#fbb710; font-size:16px;'>{dto.Amount} ₺</td></tr>
                        {(string.IsNullOrEmpty(dto.Description) ? "" : $"<tr><td style='color:#94a3b8; padding:8px 0;'>Not</td><td style='color:#0f172a;'>{dto.Description}</td></tr>")}
                    </table>
                </div>

                <p style='color:#64748b; font-size:13px;'>Herhangi bir sorunuz için bizimle iletişime geçebilirsiniz.</p>
            </div>
            <div style='background:#1d2127; padding:16px; border-radius:0 0 12px 12px; text-align:center;'>
                <p style='color:#64748b; font-size:12px; margin:0;'>© 2026 CarBook. Tüm hakları saklıdır.</p>
            </div>
        </div>";

                var bodyBuilder = new BodyBuilder { HtmlBody = body };
                message.Body = bodyBuilder.ToMessageBody();
                using var smtpClient = new SmtpClient();
                smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtpClient.Connect(host, port, false);
                smtpClient.Authenticate(from, password);
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mail gönderilemedi: " + ex.Message);
            }
        }
    }
}
