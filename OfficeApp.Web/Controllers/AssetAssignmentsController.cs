using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Inventory;

namespace OfficeApp.Web.Controllers;

public class AssetAssignmentsController : Controller
{
    private readonly IAssetAssignmentService _service;

    public AssetAssignmentsController(IAssetAssignmentService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
