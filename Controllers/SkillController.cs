using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VpGameWeb.Data;
using VpGameWeb.Models;

namespace VpGameWeb.Controllers
{
    public class SkillController : Controller
    {
        private readonly AppDbContext _context;

        public SkillController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Skill> skills = _context.Skills
                .AsNoTracking()
                .ToList();

            return View(skills);
        }

        public IActionResult Details(int id)
        {
            Skill? skill = _context.Skills
                .AsNoTracking()
                .Include(s => s.Levels)
                .FirstOrDefault(s => s.Id == id);

            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }
    }
}