using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;

namespace VpGameWeb.Controllers
{
    public class CharacterController : Controller
    {
        private static List<Character> characters = new List<Character>
        {
            new Character
            {
                Id = 1,
                Race = "人類",
                Name = "塔蘭",
                Age = "29歲",
                Hp = 100,
                MoveSpeed = 6,
                Traits = "木頭、巨根",
                Description = "戰爭孤兒，從小在教會由修女艾琳扶養長大，夢想是成為大魔法師並協助勇者討伐魔王。為了成為大魔法師而保持處男之身至今，從未交過女朋友。",
                PortraitUrl = "/images/characters/portraits/player.png",
                IconUrl = "/images/characters/player.png",
                Skills = new List<string>
                {
                    "水魔法：發射強大的水球彈。",
                    "火魔法：召喚火輪進行防禦。",
                    "岩魔法：從地下召喚巨大岩塊進行攻擊。",
                    "雷魔法：展開圓形電圈領域進行防禦。",
                    "毒魔法：發射有毒且會迅速擴散的的氣體。",
                    "雷魔法：發射會到處彈跳的閃電箭。",
                    "木魔法：發射木頭迴旋鏢。",
                }
            },
            new Character
            {
                Id = 2,
                Race = "吸血鬼",
                Name = "莉莉絲",
                Age = "25歲",
                Hp = 8000,
                Attack = 15,
                MoveSpeed = 4,
                Traits = "傲嬌、愛生氣、抖S、妹妹",
                Description = "塔蘭的青梅竹馬，喜歡稱呼塔蘭為笨蛋，對於塔蘭一直都沒察覺自己的心意感到生氣。",
                BattleScene = "夜晚的墳墓",
                MonsterGroup = "弗蘭肯斯坦、巫師、幽靈、殭屍、德古拉",
                IconUrl = "/images/characters/vampire.png",
                Skills = new List<string>
                {
                    "衝刺攻擊：朝玩家方向快速衝刺，共執行3次。",
                    "召喚小怪：在自身周圍隨機位置召喚8隻德古拉攻擊玩家。",
                    "無死角射擊：以自身為圓心，向四周發射12枚獠牙子彈。",
                }
            },
            new Character
            {
                Id = 3,
                Race = "雪女",
                Name = "由依",
                Age = "29歲",
                Hp = 12000,
                Attack = 20,
                MoveSpeed = 4,
                Traits = "無口、高冷、反差萌",
                Description = "塔蘭的青梅竹馬，一直暗戀著塔蘭，但沒有勇氣開口表達愛意。",
                BattleScene = "雪地",
                MonsterGroup = "冰雪精靈、黑暗精靈、冰魔法師、冰狼、雪怪",
                IconUrl = "/images/characters/snowwoman.png",
                Skills = new List<string>
                {
                    "衝刺射擊：朝玩家方向快速衝刺，停頓時以自身為圓心，向四周發射14枚冰彈，共執行3次。",
                    "召喚小怪：在自身周圍隨機位置召喚8隻冰狼攻擊玩家。",
                    "三重冰浪：召喚三道巨大冰浪從不同方向攻擊玩家。",
                }
            },
            new Character
            {
                Id = 4,
                Race = "魅魔",
                Name = "艾琳",
                Age = "40歲",
                Hp = 16000,
                Attack = 30,
                MoveSpeed = 5,
                Traits = "媽媽、熟女、超巨乳、疼愛、痴女",
                Description = "塔蘭的養母，喜歡稱呼塔蘭為小塔，十分溺愛塔蘭，一直忍耐著沒對塔蘭出手。",
                BattleScene = "荒蕪的岩地",
                MonsterGroup = "惡魔、眼球、小護士、紫色惡魔、雙足猛犬、四足惡犬、粉紅幽靈",
                IconUrl = "/images/characters/succubus.png",
                Skills = new List<string>
                {
                    "衝刺射擊：朝玩家方向快速衝刺，停頓時以自身為圓心，向四周發射16支愛心箭，共執行3次。",
                    "召喚小怪：在自身周圍隨機位置召喚8隻粉紅幽靈攻擊玩家，粉紅幽靈死亡後會在原地掉落一個有毒愛心，玩家撿取後會造成20傷害。。",
                    "愛心箭雨：以玩家為圓心，在圓形範圍內降下40支愛心箭攻擊玩家。",
                }
            }
        };

        public IActionResult Index()
        {
            return View(characters);
        }

        public IActionResult Details(int id)
        {
            Character? character = characters.FirstOrDefault(b => b.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }
    }
}