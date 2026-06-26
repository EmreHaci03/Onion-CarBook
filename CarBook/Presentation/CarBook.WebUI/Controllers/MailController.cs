using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
public class MailController : Controller
{
    private readonly IConfiguration _configuration;

    public MailController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult SendMail(string toEmail, string subject, string body)
    {
        var from = _configuration["MailSettings:From"];
        var fromName = _configuration["MailSettings:FromName"];
        var host = _configuration["MailSettings:Host"];
        var port = int.Parse(_configuration["MailSettings:Port"]!);
        var password = _configuration["MailSettings:Password"];

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(fromName, from));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = body };
        message.Body = bodyBuilder.ToMessageBody();

        using var client = new SmtpClient();
        client.Connect(host, port, false);
        client.Authenticate(from, password);
        client.Send(message);
        client.Disconnect(true);

        TempData["Success"] = "Mail başarıyla gönderildi.";
        return RedirectToAction("Index");
    }
}