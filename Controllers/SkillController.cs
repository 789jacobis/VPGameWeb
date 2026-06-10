using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;

namespace VpGameWeb.Controllers
{
    public class SkillController : Controller
    {
        private static List<Skill> skills = new List<Skill>()
        {
            new Skill
            {
                Id = 1,
                Name = "Basic Bullet",
                Category = "Player Skill",
                Description = "發射子彈攻擊最近敵人"
            },
            new Skill
            {
                Id = 2,
                Name = "Orbit Disk",
                Category = "Player Skill",
                Description = "召喚圓盤環繞玩家"
            },
            new Skill
            {
                Id = 3,
                Name = "Lightning",
                Category = "Player Skill",
                Description = "落雷攻擊敵人"
            }
        };

        public IActionResult Index()
        {
            return View(skills);
        }

        public IActionResult Details(int id)
        {
            Skill? skill = skills.FirstOrDefault(s => s.Id == id);

            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            skill.Id = skills.Max(s => s.Id) + 1;
            skills.Add(skill);

            return RedirectToAction("Index");
        }
    }
}