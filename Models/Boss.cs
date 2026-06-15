namespace VpGameWeb.Models
{
    public class Boss
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string RealName { get; set; } = "";

        public int Hp { get; set; }

        public int Attack { get; set; }

        public int MoveSpeed { get; set; }

        public string Description { get; set; } = "";

        public string Age { get; set; } = "";

        public string Traits { get; set; } = "";

        public string BattleScene { get; set; } = "";

        public string MonsterGroup { get; set; } = "";

        public string IconUrl { get; set; } = "";

        public List<string> Skills { get; set; } = new();
    }
}