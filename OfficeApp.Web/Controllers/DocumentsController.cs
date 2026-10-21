using Microsoft.AspNetCore.Mvc;
using OfficeApp.BL.Services.Documents;

namespace OfficeApp.Web.Controllers;

public class DocumentsController : Controller
{
    private readonly IDocumentService _service;

    public DocumentsController(IDocumentService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _service.GetAllAsync();
        return View(items);
    }
}
