using VpGameWeb.Models;

namespace VpGameWeb.Services
{
    public class LoreService
    {
        private static readonly List<Lore> Lores = new()
        {
            new Lore
            {
                Id = 1,
                Title = "世界背景",
                Category = "主線設定",
                Summary = "介紹主角塔蘭以及女主角們的背景故事",
                Content =
                "主角塔蘭是一名孤兒，從小在教會長大，擁有魔法的天賦，所以掌管教會的修女艾琳小姐特別疼愛他，經常教他各種魔法，並引導塔蘭朝魔法師的目標邁進。\n\n" +
                "在教會和塔蘭一同長大的還有兩名女孩莉莉絲和由依，她們與塔蘭是十分要好的好朋友，不過兩人並沒有魔法的天賦，因此都將成為修女做為未來的目標。\n\n" +
                "時光荏苒，塔蘭今年已經十九歲了，明天就是他的二十歲生日，他打算進入充滿魔物的禁忌森林，尋找女神所在的女神之湖，如此便能得到女神的祝福成為大魔法師。\n\n" +
                "生日當天，艾琳修女與兩位青梅竹馬們來替他送行，眾人依依不捨地在森林入口道別。臨行前，修女將自己珍藏的魔法書交給他，希望能幫助他擊退魔物。\n\n" +
                "收到眾人的祝福，塔蘭打起精神，踏入了禁忌森林，去追尋成為大魔法師的夢想，沒想到卻在森林裡遭遇了大批魔物襲擊，甚至，魔物的首領竟然與艾琳修女、莉莉絲和由依有著相似的外貌……"
            },
            new Lore
            {
                Id = 2,
                Title = "魔物起源",
                Category = "怪物設定",
                Summary = "說明怪物從何而來。",
                Content = "大部分魔物都源自詛咒所產生的魔力汙染..."
            },
            new Lore
            {
                Id = 3,
                Title = "三大魔王",
                Category = "Boss設定",
                Summary = "吸血鬼、雪女與魅魔的來歷。",
                Content = "傳說中的三位魔王分別統治不同區域..."
            }
        };

        public Task<List<Lore>> GetAllAsync()
        {
            return Task.FromResult(Lores);
        }

        public Task<Lore?> GetByIdAsync(int id)
        {
            return Task.FromResult(Lores.FirstOrDefault(l => l.Id == id));
        }
    }
}
