using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.WebUI.Controllers;

public class UserLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
