using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserSkillComponentPartial : ViewComponent
{
    private readonly IGenericService _genericService;

    public _UserSkillComponentPartial(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _genericService.SkillService.GetAllAsync();
        return View(result);
    }
}
