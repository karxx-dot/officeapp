using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.HR;

namespace OfficeApp.Web.Controllers;

public class LeaveRequestsController : Controller
{
    private readonly ILeaveRequestService _service;

    public LeaveRequestsController(ILeaveRequestService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
