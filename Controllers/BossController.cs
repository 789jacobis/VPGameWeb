using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;

namespace VpGameWeb.Controllers
{
    public class BossController : Controller
    {
        private static List<Boss> bosses = new List<Boss>
        {
            new Boss
            {
                Id = 1,
                Name = "吸血鬼",
                Hp = 3000,
                Description = "第一關 Boss，使用血獠牙與衝刺攻擊玩家。",
                IconUrl = "/images/bosses/vampire.png",
                Skills = new List<string>
                {
                    "血獠牙放射射擊",
                    "衝刺攻擊",
                    "召喚蝙蝠"
                }
            },
            new Boss
            {
                Id = 2,
                Name = "雪女",
                Hp = 4500,
                Description = "第二關 Boss，擅長冰屬性範圍攻擊。",
                IconUrl = "/images/bosses/snowwoman.png",
                Skills = new List<string>
                {
                    "三重冰浪",
                    "三連衝刺",
                    "放射冰彈"
                }
            },
            new Boss
            {
                Id = 3,
                Name = "魅魔",
                Hp = 6000,
                Description = "第三關 Boss，使用愛心箭雨與召喚技能壓迫玩家。",
                IconUrl = "/images/bosses/succubus.png",
                Skills = new List<string>
                {
                    "愛心箭雨",
                    "召喚小惡魔",
                    "假愛心掉落"
                }
            }
        };

        public IActionResult Index()
        {
            return View(bosses);
        }

        public IActionResult Details(int id)
        {
            Boss? boss = bosses.FirstOrDefault(b => b.Id == id);

            if (boss == null)
            {
                return NotFound();
            }

            return View(boss);
        }
    }
}