using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserSertificateComponentPartial : ViewComponent
{
    private readonly IGenericService _genericService;

    public _UserSertificateComponentPartial(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result= await _genericService.SertificateService.GetAllAsync();
        return View(result);
    }
}
