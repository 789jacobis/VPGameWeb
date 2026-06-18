using Microsoft.EntityFrameworkCore;
using VpGameWeb.Models;

namespace VpGameWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<SkillLevel> SkillLevels { get; set; }

        public DbSet<Monster> Monsters { get; set; }

        public DbSet<CharacterAbility> CharacterAbilities { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}