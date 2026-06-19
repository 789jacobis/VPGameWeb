using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;
using VpGameWeb.Services;

namespace VpGameWeb.Controllers
{
    public class LoreController : Controller
    {
        private readonly LoreService _service;

        public LoreController(LoreService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Lore> lores = await _service.GetAllAsync();

            return View(lores);
        }

        public async Task<IActionResult> Details(int id)
        {
            Lore? lore = await _service.GetByIdAsync(id);

            if (lore == null)
            {
                return NotFound();
            }

            return View(lore);
        }
    }
}
