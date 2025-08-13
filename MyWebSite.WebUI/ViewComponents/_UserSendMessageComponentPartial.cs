using Microsoft.AspNetCore.Mvc;
using MyWebSite.WebUI.Models;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserSendMessageComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = new ContactFormModel();
        return View(model);
    }


}
