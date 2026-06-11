using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models;

namespace VpGameWeb.Controllers
{
    public class ItemController : Controller
    {
        private static List<Item> items = new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "愛心",
                Category = "恢復道具",
                Description = "撿取後恢復玩家生命值。",
                IconUrl = "/images/items/heart.png"
            },
            new Item
            {
                Id = 2,
                Name = "假愛心",
                Category = "陷阱道具",
                Description = "外觀類似愛心，但撿取後會扣除生命值。",
                IconUrl = "/images/items/fake-heart.png"
            },
            new Item
            {
                Id = 3,
                Name = "經驗方塊",
                Category = "成長道具",
                Description = "撿取後獲得經驗值，用於角色升級。",
                IconUrl = "/images/items/exp-gem.png"
            },
            new Item
            {
                Id = 4,
                Name = "金幣",
                Category = "貨幣道具",
                Description = "可用於商店購買永久強化。",
                IconUrl = "/images/items/coin.png"
            },
            new Item
            {
                Id = 5,
                Name = "磁鐵",
                Category = "輔助道具",
                Description = "撿取後吸引附近的經驗方塊。",
                IconUrl = "/images/items/magnet.png"
            }
        };

        public IActionResult Index()
        {
            return View(items);
        }

        public IActionResult Details(int id)
        {
            Item? item = items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
    }
}