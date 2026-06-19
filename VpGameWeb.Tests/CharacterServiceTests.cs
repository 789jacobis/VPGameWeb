using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using VpGameWeb.Data;
using VpGameWeb.Models;
using VpGameWeb.Models.Dtos;
using VpGameWeb.Services;

namespace VpGameWeb.Tests;

public class CharacterServiceTests
{
    private SqliteConnection _connection = null!;
    private AppDbContext _context = null!;
    private CharacterService _service = null!;

    [SetUp]
    public async Task SetUp()
    {
        _connection = new SqliteConnection("Data Source=:memory:");
        await _connection.OpenAsync();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new AppDbContext(options);
        await _context.Database.EnsureCreatedAsync();

        _context.Characters.AddRange(
            new Character
            {
                Name = "Astra",
                Race = "human",
                Hp = 120,
                Attack = 15,
                MoveSpeed = 1.1,
                Description = "Balanced mage"
            },
            new Character
            {
                Name = "Blaze",
                Race = "demon",
                Hp = 90,
                Attack = 30,
                MoveSpeed = 1.4,
                Description = "Fast attacker"
            },
            new Character
            {
                Name = "Celine",
                Race = "human",
                Hp = 160,
                Attack = 20,
                MoveSpeed = 0.9,
                Description = "Durable caster"
            });

        await _context.SaveChangesAsync();

        _service = new CharacterService(_context);
    }

    [TearDown]
    public async Task TearDown()
    {
        await _context.DisposeAsync();
        await _connection.DisposeAsync();
    }

    [Test]
    public async Task GetAllAsync_FiltersSortsAndPaginatesCharacters()
    {
        var pagination = new PaginationQuery
        {
            Page = 1,
            PageSize = 1,
            Sort = "hp_desc"
        };

        PagedResult<CharacterDto> result = await _service.GetAllAsync("human", null, pagination);

        Assert.Multiple(() =>
        {
            Assert.That(result.TotalCount, Is.EqualTo(2));
            Assert.That(result.TotalPages, Is.EqualTo(2));
            Assert.That(result.Items, Has.Count.EqualTo(1));
            Assert.That(result.Items[0].Name, Is.EqualTo("Celine"));
            Assert.That(result.HasNextPage, Is.True);
            Assert.That(result.HasPreviousPage, Is.False);
        });
    }

    [Test]
    public async Task GetAllAsync_AppliesMinimumHpFilter()
    {
        var pagination = new PaginationQuery
        {
            Page = 1,
            PageSize = 10,
            Sort = "name_asc"
        };

        PagedResult<CharacterDto> result = await _service.GetAllAsync(null, 100, pagination);

        Assert.Multiple(() =>
        {
            Assert.That(result.TotalCount, Is.EqualTo(2));
            Assert.That(result.Items.Select(c => c.Name), Is.EqualTo(new[] { "Astra", "Celine" }));
        });
    }

    [Test]
    public async Task GetByIdAsync_ReturnsDtoForExistingCharacter()
    {
        Character character = await _context.Characters.SingleAsync(c => c.Name == "Blaze");

        CharacterDto? dto = await _service.GetByIdAsync(character.Id);

        Assert.Multiple(() =>
        {
            Assert.That(dto, Is.Not.Null);
            Assert.That(dto!.Name, Is.EqualTo("Blaze"));
            Assert.That(dto.Attack, Is.EqualTo(30));
        });
    }
}
