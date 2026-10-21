using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Operations;

namespace OfficeApp.Web.Controllers;

public class RoomsController : Controller
{
    private readonly IRoomService _service;

    public RoomsController(IRoomService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
