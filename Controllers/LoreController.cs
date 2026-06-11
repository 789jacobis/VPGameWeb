using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;

namespace VpGameWeb.Controllers
{
    public class LoreController : Controller
    {
        private static List<Lore> lores = new List<Lore>
        {
            new Lore
            {
                Id = 1,
                Title = "世界背景",
                Category = "主線設定",
                Summary = "介紹 VP 世界的起源。",
                Content = "很久以前，世界遭受魔王的詛咒，大量魔物開始出現..."
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

        public IActionResult Index()
        {
            return View(lores);
        }

        public IActionResult Details(int id)
        {
            Lore? lore = lores.FirstOrDefault(l => l.Id == id);

            if (lore == null)
            {
                return NotFound();
            }

            return View(lore);
        }
    }
}