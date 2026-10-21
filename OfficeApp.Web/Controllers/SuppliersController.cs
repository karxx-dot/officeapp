using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Inventory;

namespace OfficeApp.Web.Controllers;

public class SuppliersController : Controller
{
    private readonly ISupplierService _service;

    public SuppliersController(ISupplierService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
