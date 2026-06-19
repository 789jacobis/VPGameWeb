namespace VpGameWeb.Models
{
    public class CharacterCreateViewModel
    {
        public string Name { get; set; } = "";
        public string Race { get; set; } = "";
        public string Age { get; set; } = "";
        public int Hp { get; set; }
        public int Attack { get; set; }
        public double MoveSpeed { get; set; }
        public string Description { get; set; } = "";
        public string IconUrl { get; set; } = "";
    }
}