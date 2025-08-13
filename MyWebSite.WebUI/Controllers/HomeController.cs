using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;
using MyWebSite.WebUI.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace MyWebSite.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly IGenericService _genericService;

    public HomeController(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendMessage(string name, string email, string subject, string message)
    {
        var adminMail = _genericService.ContactService.GetAllAsync().Result.FirstOrDefault()?.Mail;
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
        {
            TempData["Message"] = "L�tfen t�m alanlar� doldurun.";
            TempData["Color"] = "red";
            return Redirect("/#iletisim");
        }

        try
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(adminMail);
            mail.To.Add(adminMail);
            mail.Subject = subject;
            mail.Body = $"G�nderen: {name} ({email})\n\nMesaj:\n{message}";
            mail.ReplyToList.Add(new MailAddress(email));

            using var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(adminMail, "okvwjcwfqjkzndeq"),
                EnableSsl = true
            };
            smtp.Send(mail);

            TempData["Message"] = "Mesaj�n�z ba�ar�yla g�nderildi.";
            TempData["Color"] = "green";
        }

        catch (FormatException)
        {
            TempData["Message"] = "L�tfen ge�erli bir e-posta adresi girin.";
            TempData["Color"] = "red";

        }
        catch (SmtpException)
        {
            TempData["Message"] = "Mail g�nderilirken sunucu hatas� olu�tu.";
            TempData["Color"] = "red";

        }
        catch (Exception ex)
        {
            TempData["Message"] = "Beklenmedik bir hata olu�tu: " + ex.Message;
            TempData["Color"] = "red";

        }

        return Redirect("/#iletisim");
    }
}

