using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Inventory;

namespace OfficeApp.Web.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
