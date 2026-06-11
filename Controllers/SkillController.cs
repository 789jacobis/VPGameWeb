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
                Category = "Starter",
                Description = "發射子彈攻擊最近敵人",
                IconUrl = "/images/skills/basic-bullet.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "發射 1 顆子彈" },
                    new SkillLevel { Level = 2, Description = "傷害 +20%" },
                    new SkillLevel { Level = 3, Description = "子彈數量 +1" },
                    new SkillLevel { Level = 4, Description = "傷害 +20%" },
                    new SkillLevel { Level = 5, Description = "子彈數量 +1" },
                    new SkillLevel { Level = 6, Description = "攻擊速度提升" }
                }
            },
            new Skill
            {
                Id = 2,
                Name = "Orbit Disk",
                Category = "Upgrade",
                Description = "召喚火輪環繞玩家",
                IconUrl = "/images/skills/orbit-disk.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "解鎖火輪" },
                    new SkillLevel { Level = 2, Description = "火輪+1" },
                    new SkillLevel { Level = 3, Description = "火輪+1" },
                    new SkillLevel { Level = 4, Description = "火輪+1" },
                    new SkillLevel { Level = 5, Description = "火輪+1" },
                    new SkillLevel { Level = 6, Description = "火輪+1" }
                }
            },
            new Skill
            {
                Id = 3,
                Name = "Lightning",
                Category = "Upgrade",
                Description = "落雷攻擊敵人",
                IconUrl = "/images/skills/lightning.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "解鎖落雷" },
                    new SkillLevel { Level = 2, Description = "落雷+1" },
                    new SkillLevel { Level = 3, Description = "落雷+1" },
                    new SkillLevel { Level = 4, Description = "落雷+1" },
                    new SkillLevel { Level = 5, Description = "落雷+1" },
                    new SkillLevel { Level = 6, Description = "落雷+1" }
                }
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
    }
}