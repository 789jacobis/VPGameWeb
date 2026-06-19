using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;
using VpGameWeb.Services;

namespace VpGameWeb.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Character> characters = await _service.GetAllForViewAsync();

            return View(characters);
        }

        public async Task<IActionResult> Details(int id)
        {
            Character? character = await _service.GetByIdForViewAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CharacterCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _service.CreateAsync(vm);

            return RedirectToAction("Index");
        }
    }
}
