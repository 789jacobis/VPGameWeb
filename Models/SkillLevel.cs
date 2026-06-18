namespace VpGameWeb.Models
{
    public class SkillLevel
    {
        public int Id { get; set; }

        public int Level { get; set; }

        public string Description { get; set; } = "";

        public int SkillId { get; set; }

        public Skill Skill { get; set; } = null!;
    }
}