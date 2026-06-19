using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;
using VpGameWeb.Services;

namespace VpGameWeb.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _service;

        public SkillController(ISkillService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Skill> skills = await _service.GetAllForViewAsync();

            return View(skills);
        }

        public async Task<IActionResult> Details(int id)
        {
            Skill? skill = await _service.GetByIdForViewAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }
    }
}
