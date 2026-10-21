using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Operations;

namespace OfficeApp.Web.Controllers;

public class TaskItemsController : Controller
{
    private readonly ITaskItemService _service;

    public TaskItemsController(ITaskItemService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
