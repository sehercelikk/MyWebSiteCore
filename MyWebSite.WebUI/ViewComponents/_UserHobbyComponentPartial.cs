using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserHobbyComponentPartial : ViewComponent
{
    private readonly IGenericService _genericService;

    public _UserHobbyComponentPartial(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _genericService.HobbyService.GetAllAsync();
        return View(result);
    }
}
