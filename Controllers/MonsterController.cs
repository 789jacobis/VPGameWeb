using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VpGameWeb.Data;
using VpGameWeb.Models;

namespace VpGameWeb.Controllers
{
    public class MonsterController : Controller
    {
        private readonly AppDbContext _context;

        public MonsterController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Monster> monsters = _context.Monsters
                .AsNoTracking()
                .ToList();

            return View(monsters);
        }

        public IActionResult Details(int id)
        {
            Monster? monster = _context.Monsters
                .AsNoTracking()
                .FirstOrDefault(m => m.Id == id);

            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }
    }
}