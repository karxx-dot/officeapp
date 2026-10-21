using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Operations;

namespace OfficeApp.Web.Controllers;

public class MeetingsController : Controller
{
    private readonly IMeetingService _service;

    public MeetingsController(IMeetingService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
