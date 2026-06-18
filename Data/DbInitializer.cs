using VpGameWeb.Models;

namespace VpGameWeb.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            SeedCharacters(context);
            SeedSkills(context);
            SeedMonsters(context);
        }

        private static void SeedCharacters(AppDbContext context)
        {
            if (context.Characters.Any())
            {
                return;
            }
            List<Character> characters = new List<Character>
            {
                new Character
                {
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
                        "毒魔法：發射有毒且會迅速擴散的氣體。",
                        "雷魔法：發射會到處彈跳的閃電箭。",
                        "木魔法：發射木頭迴旋鏢。"
                    }
                },

                new Character
                {
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
                        "無死角射擊：以自身為圓心，向四周發射12枚獠牙子彈。"
                    }
                },

                new Character
                {
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
                        "三重冰浪：召喚三道巨大冰浪從不同方向攻擊玩家。"
                    }
                },

                new Character
                {
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
                        "召喚小怪：在自身周圍隨機位置召喚8隻粉紅幽靈攻擊玩家，粉紅幽靈死亡後會在原地掉落一個有毒愛心，玩家撿取後會造成20傷害。",
                        "愛心箭雨：以玩家為圓心，在圓形範圍內降下40支愛心箭攻擊玩家。"
                    }
                }
            };
            context.Characters.AddRange(characters);
            context.SaveChanges();
        }

        private static void SeedSkills(AppDbContext context)
        {
            if (context.Skills.Any())
            {
                return;
            }

            List<Skill> skills = new List<Skill>
            {
                new Skill
                {
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
                }
            };
            context.Skills.AddRange(skills);
            context.SaveChanges();
        }

        private static void SeedMonsters(AppDbContext context)
        {
            if (context.Monsters.Any())
            {
                return;
            }

            List<Monster> monsters = new List<Monster>
    {
        new Monster
        {
            Name = "弗蘭肯斯坦",
            Type = "近戰",
            Hp = 15,
            Attack = 3,
            MoveSpeed = 3,
            ExpReward = 5,
            Description = "無特殊能力的近戰小怪，能輕易擊殺。",
            IconUrl = "/images/monsters/frankenstein.png"
        },
        new Monster
        {
            Name = "巫師",
            Type = "遠程",
            Hp = 30,
            Attack = 4,
            MoveSpeed = 4,
            ExpReward = 7,
            Description = "會與玩家保持距離的遠程小怪，每2秒朝玩家發射1顆傷害為7的子彈。",
            IconUrl = "/images/monsters/wizard.png"
        },
        new Monster
        {
            Name = "幽靈",
            Type = "近戰",
            Hp = 30,
            Attack = 3,
            MoveSpeed = 5,
            ExpReward = 10,
            Description = "移動速度極快，且血量極低的近戰小怪。",
            IconUrl = "/images/monsters/ghost.png"
        },
        new Monster
        {
            Name = "殭屍",
            Type = "近戰",
            Hp = 120,
            Attack = 10,
            MoveSpeed = 2.5,
            ExpReward = 12,
            Description = "移動速度極慢，且血量極高的近戰小怪。",
            IconUrl = "/images/monsters/zombie.png"
        },
        new Monster
        {
            Name = "德古拉",
            Type = "近戰",
            Hp = 100,
            Attack = 8,
            MoveSpeed = 2,
            ExpReward = 12,
            Description = "移動速度極慢的近戰小怪，但衝刺時速度會大幅提升。",
            IconUrl = "/images/monsters/dracula.png"
        },
        new Monster
        {
            Name = "冰雪精靈",
            Type = "近戰",
            Hp = 17,
            Attack = 4,
            MoveSpeed = 3,
            ExpReward = 5,
            Description = "無特殊能力的近戰小怪，能輕易擊殺。",
            IconUrl = "/images/monsters/snowelf.png"
        },
        new Monster
        {
            Name = "黑暗精靈",
            Type = "近戰",
            Hp = 21,
            Attack = 4,
            MoveSpeed = 4,
            ExpReward = 10,
            Description = "死亡後會在原地留下毒液的近戰小怪。",
            IconUrl = "/images/monsters/dark-snowelf.png"
        },
        new Monster
        {
            Name = "冰魔法師",
            Type = "遠程",
            Hp = 50,
            Attack = 5,
            MoveSpeed = 4,
            ExpReward = 10,
            Description = "會與玩家保持距離的遠程小怪，每2秒朝玩家發射3顆傷害為9的子彈。",
            IconUrl = "/images/monsters/ice-wizard.png"
        },
        new Monster
        {
            Name = "冰狼",
            Type = "近戰",
            Hp = 45,
            Attack = 6,
            MoveSpeed = 5,
            ExpReward = 10,
            Description = "移動速度極快，且血量極低的近戰小怪。",
            IconUrl = "/images/monsters/snowwolf.png"
        },
        new Monster
        {
            Name = "雪怪",
            Type = "近戰",
            Hp = 135,
            Attack = 12,
            MoveSpeed = 2.5,
            ExpReward = 12,
            Description = "移動速度極慢，且血量極高的近戰小怪。",
            IconUrl = "/images/monsters/yeti.png"
        },
        new Monster
        {
            Name = "惡魔",
            Type = "近戰",
            Hp = 30,
            Attack = 4,
            MoveSpeed = 3,
            ExpReward = 5,
            Description = "無特殊能力的近戰小怪，能輕易擊殺。",
            IconUrl = "/images/monsters/devil.png"
        },
        new Monster
        {
            Name = "眼球",
            Type = "遠程",
            Hp = 55,
            Attack = 5,
            MoveSpeed = 4,
            ExpReward = 11,
            Description = "會與玩家保持距離的遠程小怪，每2秒朝玩家發射3顆傷害為10的子彈。",
            IconUrl = "/images/monsters/eyeball.png"
        },
        new Monster
        {
            Name = "小護士",
            Type = "近戰",
            Hp = 125,
            Attack = 11,
            MoveSpeed = 2,
            ExpReward = 13,
            Description = "移動速度極慢的近戰小怪，但衝刺時速度會大幅提升。",
            IconUrl = "/images/monsters/nurse.png"
        },
        new Monster
        {
            Name = "紫色惡魔",
            Type = "近戰",
            Hp = 50,
            Attack = 5,
            MoveSpeed = 4,
            ExpReward = 10,
            Description = "死亡後會在原地留下毒液的近戰小怪。",
            IconUrl = "/images/monsters/purple-devil.png"
        },
        new Monster
        {
            Name = "雙足猛犬",
            Type = "近戰",
            Hp = 155,
            Attack = 12,
            MoveSpeed = 2.5,
            ExpReward = 10,
            Description = "移動速度極慢，且血量極高的近戰小怪。",
            IconUrl = "/images/monsters/big-dog.png"
        },
        new Monster
        {
            Name = "四足惡犬",
            Type = "近戰",
            Hp = 55,
            Attack = 6,
            MoveSpeed = 5,
            ExpReward = 11,
            Description = "移動速度極快，且血量極低的近戰小怪。",
            IconUrl = "/images/monsters/small-dog.png"
        },
        new Monster
        {
            Name = "粉紅幽靈",
            Type = "近戰",
            Hp = 40,
            Attack = 4,
            MoveSpeed = 4,
            ExpReward = 0,
            Description = "會在原地掉落一個有毒愛心，玩家撿取後會造成20傷害。",
            IconUrl = "/images/monsters/pink-ghost.png"
        }
    };

            context.Monsters.AddRange(monsters);
            context.SaveChanges();
        }
    }
}