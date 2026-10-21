using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Operations;

namespace OfficeApp.Web.Controllers;

public class MeetingAttendeesController : Controller
{
    private readonly IMeetingAttendeeService _service;

    public MeetingAttendeesController(IMeetingAttendeeService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
