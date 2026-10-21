using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Operations;

namespace OfficeApp.Web.Controllers;

public class ReservationsController : Controller
{
    private readonly IReservationService _service;

    public ReservationsController(IReservationService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
