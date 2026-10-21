using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.HR;

namespace OfficeApp.Web.Controllers;

public class PositionsController : Controller
{
    private readonly IPositionService _service;

    public PositionsController(IPositionService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
