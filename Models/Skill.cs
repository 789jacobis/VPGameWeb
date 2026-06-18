namespace VpGameWeb.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Category { get; set; } = "";

        public string Description { get; set; } = "";

        public string IconUrl { get; set; } = "";

        public List<SkillLevel> Levels { get; set; } = new();
    }
}