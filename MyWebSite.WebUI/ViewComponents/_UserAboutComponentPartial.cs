using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;
using MyWebSite.WebUI.Models;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserAboutComponentPartial : ViewComponent
{
    private readonly IGenericService _genericService;

    public _UserAboutComponentPartial(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var vm = new AboutPageViewModel
        {
            Abouts = await _genericService.MyAboutService.GetAllAsync(),
            JobDescriptions = await _genericService.JobDescriptionService.GetAllAsync(),
        };
        return View(vm);
    }
}
