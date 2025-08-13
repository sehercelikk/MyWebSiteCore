using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
