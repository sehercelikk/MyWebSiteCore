using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserProjectComponentPartial : ViewComponent
{
    private readonly IGenericService _genericService;

    public _UserProjectComponentPartial(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _genericService.ProjectService.GetAllAsync();
        return View(result);
    }
}
