using Microsoft.EntityFrameworkCore;
using VpGameWeb.Data;
using VpGameWeb.Models;
using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly AppDbContext _context;

        public CharacterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Character>> GetAllForViewAsync()
        {
            return await _context.Characters
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Character?> GetByIdForViewAsync(int id)
        {
            return await _context.Characters
                .AsNoTracking()
                .Include(c => c.Abilities)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Character> CreateAsync(CharacterCreateViewModel vm)
        {
            Character character = new Character
            {
                Name = vm.Name,
                Race = vm.Race,
                Age = vm.Age,
                Hp = vm.Hp,
                Attack = vm.Attack,
                MoveSpeed = vm.MoveSpeed,
                Description = vm.Description,
                IconUrl = vm.IconUrl
            };

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return character;
        }

        public async Task<PagedResult<CharacterDto>> GetAllAsync(
            string? race,
            int? minHp,
            PaginationQuery pagination)
        {
            var query = _context.Characters
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(race))
            {
                query = query.Where(c => c.Race == race);
            }

            if (minHp.HasValue)
            {
                query = query.Where(c => c.Hp >= minHp);
            }

            query = ApplySorting(query, pagination.Sort);

            int totalCount = await query.CountAsync();
            List<CharacterDto> items = await query
                .Skip(pagination.Skip)
                .Take(pagination.PageSize)
                .Select(c => new CharacterDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Race = c.Race,
                    Hp = c.Hp,
                    Attack = c.Attack,
                    MoveSpeed = c.MoveSpeed,
                    Description = c.Description,
                    Age = c.Age,
                    Traits = c.Traits,
                    BattleScene = c.BattleScene,
                    MonsterGroup = c.MonsterGroup,
                    PortraitUrl = c.PortraitUrl,
                    IconUrl = c.IconUrl,
                    Abilities = c.Abilities
                        .Select(a => new CharacterAbilityDto
                        {
                            Id = a.Id,
                            Description = a.Description
                        })
                        .ToList()
                })
                .ToListAsync();

            return CreatePagedResult(items, pagination, totalCount);
        }

        public async Task<CharacterDto?> GetByIdAsync(int id)
        {
            return await _context.Characters
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CharacterDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Race = c.Race,
                    Hp = c.Hp,
                    Attack = c.Attack,
                    MoveSpeed = c.MoveSpeed,
                    Description = c.Description,
                    Age = c.Age,
                    Traits = c.Traits,
                    BattleScene = c.BattleScene,
                    MonsterGroup = c.MonsterGroup,
                    PortraitUrl = c.PortraitUrl,
                    IconUrl = c.IconUrl,
                    Abilities = c.Abilities
                        .Select(a => new CharacterAbilityDto
                        {
                            Id = a.Id,
                            Description = a.Description
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        private static IQueryable<Character> ApplySorting(IQueryable<Character> query, string? sort)
        {
            return sort?.ToLowerInvariant() switch
            {
                "name_asc" => query.OrderBy(c => c.Name),
                "name_desc" => query.OrderByDescending(c => c.Name),
                "race_asc" => query.OrderBy(c => c.Race).ThenBy(c => c.Id),
                "race_desc" => query.OrderByDescending(c => c.Race).ThenBy(c => c.Id),
                "hp_asc" => query.OrderBy(c => c.Hp).ThenBy(c => c.Id),
                "hp_desc" => query.OrderByDescending(c => c.Hp).ThenBy(c => c.Id),
                "attack_asc" => query.OrderBy(c => c.Attack).ThenBy(c => c.Id),
                "attack_desc" => query.OrderByDescending(c => c.Attack).ThenBy(c => c.Id),
                "movespeed_asc" => query.OrderBy(c => c.MoveSpeed).ThenBy(c => c.Id),
                "movespeed_desc" => query.OrderByDescending(c => c.MoveSpeed).ThenBy(c => c.Id),
                "id_desc" => query.OrderByDescending(c => c.Id),
                _ => query.OrderBy(c => c.Id)
            };
        }

        private static PagedResult<CharacterDto> CreatePagedResult(
            List<CharacterDto> items,
            PaginationQuery pagination,
            int totalCount)
        {
            return new PagedResult<CharacterDto>
            {
                Items = items,
                Page = pagination.Page,
                PageSize = pagination.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize)
            };
        }
    }
}
