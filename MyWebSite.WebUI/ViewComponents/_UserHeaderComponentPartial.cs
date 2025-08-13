using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;
using System.Threading.Tasks;

namespace MyWebSite.WebUI.ViewComponents;

public class _UserHeaderComponentPartial : ViewComponent
{
    private readonly IGenericService _genericService;

    public _UserHeaderComponentPartial(IGenericService genericService)
    {
        _genericService = genericService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _genericService.ContactService.GetAllAsync();
        return View(result);
    }
}
