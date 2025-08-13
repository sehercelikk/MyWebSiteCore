using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.WebUI.Controllers;

public class ErrorController : Controller
{
    [Route("Error/{statusCode}")]
    public IActionResult HttpStatusCodeHandler(int statusCode)
    {
        if(statusCode==404)
        {
            ViewBag.ErrorMessage = "Aradığınız sayfa bulunamadı.";
            return View("NotFound");
        }
        ViewBag.ErrorMessage = "Bir hata oluştu.";
        return View("GeneralError");
    }
}
