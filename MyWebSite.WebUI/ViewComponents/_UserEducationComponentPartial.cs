using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserEducationComponentPartial : ViewComponent
{
    private readonly IGenericService _genericService;

    public _UserEducationComponentPartial(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _genericService.EducationService.GetAllAsync();
        result = result.OrderByDescending(x => x.Id).ToList();
        return View(result);
    }
}
