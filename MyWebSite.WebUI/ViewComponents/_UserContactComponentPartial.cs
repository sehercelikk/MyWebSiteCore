using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserContactComponentPartial : ViewComponent
{
    private readonly IGenericService _genericService;

    public _UserContactComponentPartial(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result= await _genericService.ContactService.GetAllAsync();
        return View(result);
    }
}
