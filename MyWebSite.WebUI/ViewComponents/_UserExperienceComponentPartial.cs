using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserExperienceComponentPartial : ViewComponent
{
    private readonly IGenericService _genericService;

    public _UserExperienceComponentPartial(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _genericService.ExperienceService.GetAllAsync();
        result = result.OrderByDescending(x => x.Id).ToList();
        return View(result);
    }
}
