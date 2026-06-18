using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VpGameWeb.Data;
using VpGameWeb.Models;

namespace VpGameWeb.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Item> items = _context.Items
                .AsNoTracking()
                .ToList();

            return View(items);
        }

        public IActionResult Details(int id)
        {
            Item? item = _context.Items
                .AsNoTracking()
                .FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
    }
}