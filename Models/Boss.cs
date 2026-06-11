namespace VpGameWeb.Models
{
    public class Boss
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int Hp { get; set; }

        public string Description { get; set; } = "";

        public string IconUrl { get; set; } = "";

        public List<string> Skills { get; set; } = new List<string>();
    }
}