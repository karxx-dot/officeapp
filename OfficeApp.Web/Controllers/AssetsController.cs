using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Inventory;

namespace OfficeApp.Web.Controllers;

public class AssetsController : Controller
{
    private readonly IAssetService _service;

    public AssetsController(IAssetService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
