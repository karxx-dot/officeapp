using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Documents;

namespace OfficeApp.Web.Controllers;

public class DocumentTypesController : Controller
{
    private readonly IDocumentTypeService _service;

    public DocumentTypesController(IDocumentTypeService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
