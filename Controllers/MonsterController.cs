using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;

namespace VpGameWeb.Controllers
{
    public class MonsterController : Controller
    {
        private static List<Monster> monsters = new List<Monster>
        {
            new Monster
            {
                Id = 1,
                Name = "Zombie",
                Type = "Basic Monster",
                Hp = 30,
                Attack = 5,
                Description = "最基礎的近戰怪物，會追蹤玩家。"
            },
            new Monster
            {
                Id = 2,
                Name = "Ghost",
                Type = "Fast Monster",
                Hp = 20,
                Attack = 4,
                Description = "移動速度較快，血量較低。"
            },
            new Monster
            {
                Id = 3,
                Name = "Shooter",
                Type = "Ranged Monster",
                Hp = 25,
                Attack = 6,
                Description = "會保持距離並發射子彈攻擊玩家。"
            }
        };

        public IActionResult Index()
        {
            return View(monsters);
        }

        public IActionResult Details(int id)
        {
            Monster? monster = monsters.FirstOrDefault(m => m.Id == id);

            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }
    }
}