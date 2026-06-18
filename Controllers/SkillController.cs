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
                Category = "初始技能",
                Description = "發射水球攻擊離自身最近的敵人",
                IconUrl = "/images/skills/basic-bullet.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "發射1顆水球攻擊敵人" },
                    new SkillLevel { Level = 2, Description = "水球數量增加、傷害增加" },
                    new SkillLevel { Level = 3, Description = "水球數量增加、傷害增加" },
                    new SkillLevel { Level = 4, Description = "水球數量增加、傷害增加" },
                    new SkillLevel { Level = 5, Description = "水球數量增加、傷害增加" },
                    new SkillLevel { Level = 6, Description = "水球數量增加、傷害增加" }
                }
            },
            new Skill
            {
                Id = 2,
                Name = "火輪",
                Category = "場內解鎖技能",
                Description = "召喚火輪圍繞玩家旋轉",
                IconUrl = "/images/skills/orbit-disk.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "解鎖火輪" },
                    new SkillLevel { Level = 2, Description = "火輪數量增加、傷害增加、轉速增加" },
                    new SkillLevel { Level = 3, Description = "火輪數量增加、傷害增加、轉速增加" },
                    new SkillLevel { Level = 4, Description = "火輪數量增加、傷害增加、轉速增加" },
                    new SkillLevel { Level = 5, Description = "火輪數量增加、傷害增加、轉速增加" },
                    new SkillLevel { Level = 6, Description = "火輪常駐、傷害增加、轉速增加" }
                }
            },
            new Skill
            {
                Id = 3,
                Name = "岩塊衝擊",
                Category = "場內解鎖技能",
                Description = "從地下召喚岩塊攻擊敵人",
                IconUrl = "/images/skills/lightning.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "解鎖岩塊衝擊" },
                    new SkillLevel { Level = 2, Description = "岩塊數量增加、傷害增加" },
                    new SkillLevel { Level = 3, Description = "岩塊數量增加、傷害增加、範圍增加" },
                    new SkillLevel { Level = 4, Description = "岩塊數量增加、傷害增加" },
                    new SkillLevel { Level = 5, Description = "岩塊數量增加、傷害增加" },
                    new SkillLevel { Level = 6, Description = "岩塊數量增加、傷害增加、範圍增加" }
                }
            },
                new Skill
            {
                Id = 4,
                Name = "電圈",
                Category = "場內解鎖技能",
                Description = "展開圓形電圈攻擊領域內的敵人",
                IconUrl = "/images/skills/poison-aura.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "解鎖電圈" },
                    new SkillLevel { Level = 2, Description = "電圈範圍增加、傷害增加" },
                    new SkillLevel { Level = 3, Description = "電圈範圍增加、傷害增加" },
                    new SkillLevel { Level = 4, Description = "電圈範圍增加、傷害增加" },
                    new SkillLevel { Level = 5, Description = "電圈範圍增加、傷害增加" },
                    new SkillLevel { Level = 6, Description = "電圈範圍增加、傷害增加" }
                }
            },
            new Skill
            {
                Id = 5,
                Name = "毒煙",
                Category = "場內解鎖技能",
                Description = "朝敵人發射毒煙，毒煙會在敵人之間彈跳",
                IconUrl = "/images/skills/bouncing-ball.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "解鎖毒煙" },
                    new SkillLevel { Level = 2, Description = "彈跳次數增加、傷害增加" },
                    new SkillLevel { Level = 3, Description = "毒煙數量增加、傷害增加" },
                    new SkillLevel { Level = 4, Description = "彈跳次數增加、傷害增加" },
                    new SkillLevel { Level = 5, Description = "毒煙數量增加、彈跳次數增加、傷害增加" },
                    new SkillLevel { Level = 6, Description = "毒煙數量增加、傷害增加、轉為範圍傷害" }
                }
            },
            new Skill
            {
                Id = 6,
                Name = "閃電箭",
                Category = "場內解鎖技能",
                Description = "朝敵人發射閃電箭，閃電箭撞牆後會反彈",
                IconUrl = "/images/skills/spring.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "解鎖閃電箭" },
                    new SkillLevel { Level = 2, Description = "閃電箭數量增加、傷害增加" },
                    new SkillLevel { Level = 3, Description = "閃電箭數量增加" },
                    new SkillLevel { Level = 4, Description = "閃電箭數量增加、傷害增加" },
                    new SkillLevel { Level = 5, Description = "閃電箭數量增加" },
                    new SkillLevel { Level = 6, Description = "閃電箭數量增加、傷害增加" }
                }
            },
            new Skill
            {
                Id = 7,
                Name = "迴旋鏢",
                Category = "場內解鎖技能",
                Description = "朝敵人發射迴旋鏢，迴旋鏢發射後會飛回來",
                IconUrl = "/images/skills/boomerang.png",

                Levels = new List<SkillLevel>
                {
                    new SkillLevel { Level = 1, Description = "解鎖迴旋鏢" },
                    new SkillLevel { Level = 2, Description = "迴旋鏢數量增加" },
                    new SkillLevel { Level = 3, Description = "傷害增加" },
                    new SkillLevel { Level = 4, Description = "迴旋鏢變大" },
                    new SkillLevel { Level = 5, Description = "迴旋鏢變大、傷害增加" },
                    new SkillLevel { Level = 6, Description = "迴旋鏢變大、數量增加、CD減少" }
                }
            },
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