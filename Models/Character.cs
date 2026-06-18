namespace VpGameWeb.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Race { get; set; } = "";

        public int Hp { get; set; }

        public int Attack { get; set; }

        public int MoveSpeed { get; set; }

        public string Description { get; set; } = "";

        public string Age { get; set; } = "";

        public string Traits { get; set; } = "";

        public string BattleScene { get; set; } = "";

        public string MonsterGroup { get; set; } = "";

        public string PortraitUrl { get; set; } = "";

        public string IconUrl { get; set; } = "";

        public List<CharacterAbility> Abilities { get; set; } = new();
    }
}