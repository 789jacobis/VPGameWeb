using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;
using VpGameWeb.Services;

namespace VpGameWeb.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Item> items = await _service.GetAllForViewAsync();

            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            Item? item = await _service.GetByIdForViewAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
    }
}
