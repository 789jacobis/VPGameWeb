using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;
using VpGameWeb.Services;

namespace VpGameWeb.Controllers
{
    public class MonsterController : Controller
    {
        private readonly IMonsterService _service;

        public MonsterController(IMonsterService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Monster> monsters = await _service.GetAllForViewAsync();

            return View(monsters);
        }

        public async Task<IActionResult> Details(int id)
        {
            Monster? monster = await _service.GetByIdForViewAsync(id);

            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }
    }
}
