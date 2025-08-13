using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.WebUI.Controllers;

public class AdminLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
