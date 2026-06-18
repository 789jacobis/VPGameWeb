namespace VpGameWeb.Models
{
    public class CharacterAbility
    {
        public int Id { get; set; }

        public string Description { get; set; } = "";

        public int CharacterId { get; set; }

        public Character Character { get; set; } = null!;
    }
}