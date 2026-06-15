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
                Name = "弗蘭肯斯坦",
                Type = "近戰",
                Hp = 15,
                Attack = 3,
                MoveSpeed = 3,
                ExpReward = 5,
                Description = "無特殊能力的近戰小怪，能輕易擊殺。",
                IconUrl = "/images/monsters/frankenstein.png",
            },
            new Monster
            {
                Id = 2,
                Name = "巫師",
                Type = "遠程",
                Hp = 30,
                Attack = 4,
                MoveSpeed = 4,
                ExpReward = 7,
                Description = "會與玩家保持距離的遠程小怪，每2秒朝玩家發射1顆傷害為7的子彈。",
                IconUrl = "/images/monsters/wizard.png",
            },
            new Monster
            {
                Id = 3,
                Name = "幽靈",
                Type = "近戰",
                Hp = 30,
                Attack = 3,
                MoveSpeed = 5,
                ExpReward = 10,
                Description = "移動速度極快，且血量極低的近戰小怪。",
                IconUrl = "/images/monsters/ghost.png",
            },
            new Monster
            {
                Id = 4,
                Name = "殭屍",
                Type = "近戰",
                Hp = 120,
                Attack = 10,
                MoveSpeed = 2.5,
                ExpReward = 12,
                Description = "移動速度極慢，且血量極高的近戰小怪。",
                IconUrl = "/images/monsters/zombie.png",
            },
            new Monster
            {
                Id = 5,
                Name = "德古拉",
                Type = "近戰",
                Hp = 100,
                Attack = 8,
                MoveSpeed = 2,
                ExpReward = 12,
                Description = "移動速度極慢的近戰小怪，但衝刺時速度會大幅提升。",
                IconUrl = "/images/monsters/dracula.png",
            },
            new Monster
            {
                Id = 6,
                Name = "冰雪精靈",
                Type = "近戰",
                Hp = 17,
                Attack = 4,
                MoveSpeed = 3,
                ExpReward = 5,
                Description = "無特殊能力的近戰小怪，能輕易擊殺。",
                IconUrl = "/images/monsters/snowelf.png",
            },
            new Monster
            {
                Id = 7,
                Name = "黑暗精靈",
                Type = "近戰",
                Hp = 21,
                Attack = 4,
                MoveSpeed = 4,
                ExpReward = 10,
                Description = "死亡後會在原地留下毒液的近戰小怪。",
                IconUrl = "/images/monsters/dark-snowelf.png",
            },
            new Monster
            {
                Id = 8,
                Name = "冰魔法師",
                Type = "遠程",
                Hp = 50,
                Attack = 5,
                MoveSpeed = 4,
                ExpReward = 10,
                Description = "會與玩家保持距離的遠程小怪，每2秒朝玩家發射3顆傷害為9的子彈。",
                IconUrl = "/images/monsters/ice-wizard.png",
            },
            new Monster
            {
                Id = 9,
                Name = "冰狼",
                Type = "近戰",
                Hp = 45,
                Attack = 6,
                MoveSpeed = 5,
                ExpReward = 10,
                Description = "移動速度極快，且血量極低的近戰小怪。",
                IconUrl = "/images/monsters/snowwolf.png",
            },
            new Monster
            {
                Id = 10,
                Name = "雪怪",
                Type = "近戰",
                Hp = 135,
                Attack = 12,
                MoveSpeed = 2.5,
                ExpReward = 12,
                Description = "移動速度極慢，且血量極高的近戰小怪。",
                IconUrl = "/images/monsters/yeti.png",
            },
            new Monster
            {
                Id = 11,
                Name = "惡魔",
                Type = "近戰",
                Hp = 30,
                Attack = 4,
                MoveSpeed = 3,
                ExpReward = 5,
                Description = "無特殊能力的近戰小怪，能輕易擊殺。",
                IconUrl = "/images/monsters/devil.png",
            },
            new Monster
            {
                Id = 12,
                Name = "眼球",
                Type = "遠程",
                Hp = 55,
                Attack = 5,
                MoveSpeed = 4,
                ExpReward = 11,
                Description = "會與玩家保持距離的遠程小怪，每2秒朝玩家發射3顆傷害為10的子彈。",
                IconUrl = "/images/monsters/eyeball.png",
            },
            new Monster
            {
                Id = 13,
                Name = "小護士",
                Type = "近戰",
                Hp = 125,
                Attack = 11,
                MoveSpeed = 2,
                ExpReward = 13,
                Description = "移動速度極慢的近戰小怪，但衝刺時速度會大幅提升。",
                IconUrl = "/images/monsters/nurse.png",
            },
            new Monster
            {
                Id = 14,
                Name = "紫色惡魔",
                Type = "近戰",
                Hp = 50,
                Attack = 5,
                MoveSpeed = 4,
                ExpReward = 10,
                Description = "死亡後會在原地留下毒液的近戰小怪。",
                IconUrl = "/images/monsters/purple-devil.png",
            },
            new Monster
            {
                Id = 15,
                Name = "雙足猛犬",
                Type = "近戰",
                Hp = 155,
                Attack = 12,
                MoveSpeed = 2.5,
                ExpReward = 10,
                Description = "移動速度極慢，且血量極高的近戰小怪。",
                IconUrl = "/images/monsters/big-dog.png",
            },
            new Monster
            {
                Id = 16,
                Name = "四足惡犬",
                Type = "近戰",
                Hp = 55,
                Attack = 6,
                MoveSpeed = 5,
                ExpReward = 11,
                Description = "移動速度極快，且血量極低的近戰小怪。",
                IconUrl = "/images/monsters/small-dog.png",
            },
            new Monster
            {
                Id = 17,
                Name = "粉紅幽靈",
                Type = "近戰",
                Hp = 40,
                Attack = 4,
                MoveSpeed = 4,
                ExpReward = 0,
                Description = "會在原地掉落一個有毒愛心，玩家撿取後會造成20傷害。",
                IconUrl = "/images/monsters/pink-ghost.png",
            },
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