using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VpGameWeb.Models;
using VpGameWeb.Data;

namespace VpGameWeb.Controllers
{
    public class CharacterController : Controller
    {
        private readonly AppDbContext _context;

        public CharacterController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Character> characters = _context.Characters
                .AsNoTracking()
                .ToList();

            return View(characters);
        }

        public IActionResult Details(int id)
        {
            Character? character = _context.Characters
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }
    }
}