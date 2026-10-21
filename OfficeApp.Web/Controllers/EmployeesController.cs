using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.HR;

namespace OfficeApp.Web.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeService _service;

    public EmployeesController(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
