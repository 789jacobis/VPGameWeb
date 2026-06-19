namespace VpGameWeb.Models.Dtos
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Race { get; set; } = "";
        public int Hp { get; set; }
        public int Attack { get; set; }
        public double MoveSpeed { get; set; }
        public string Description { get; set; } = "";
        public string Age { get; set; } = "";
        public string Traits { get; set; } = "";
        public string BattleScene { get; set; } = "";
        public string MonsterGroup { get; set; } = "";
        public string PortraitUrl { get; set; } = "";
        public string IconUrl { get; set; } = "";
        public List<CharacterAbilityDto> Abilities { get; set; } = new();
    }
}
