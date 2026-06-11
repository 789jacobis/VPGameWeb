namespace VpGameWeb.Models
{
    public class Monster
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Type { get; set; } = "";

        public int Hp { get; set; }

        public int Attack { get; set; }

        public string Description { get; set; } = "";
    }
}