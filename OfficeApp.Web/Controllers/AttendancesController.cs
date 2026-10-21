using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.HR;

namespace OfficeApp.Web.Controllers;

public class AttendancesController : Controller
{
    private readonly IAttendanceService _service;

    public AttendancesController(IAttendanceService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
