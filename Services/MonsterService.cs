using Microsoft.EntityFrameworkCore;
using VpGameWeb.Data;
using VpGameWeb.Models;
using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly AppDbContext _context;

        public MonsterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Monster>> GetAllForViewAsync()
        {
            return await _context.Monsters
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Monster?> GetByIdForViewAsync(int id)
        {
            return await _context.Monsters
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedResult<MonsterDto>> GetAllAsync(
            string? type,
            int? minHp,
            PaginationQuery pagination)
        {
            var query = _context.Monsters
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(type))
            {
                query = query.Where(m => m.Type == type);
            }

            if (minHp.HasValue)
            {
                query = query.Where(m => m.Hp >= minHp);
            }

            query = ApplySorting(query, pagination.Sort);

            int totalCount = await query.CountAsync();
            List<MonsterDto> items = await query
                .Skip(pagination.Skip)
                .Take(pagination.PageSize)
                .Select(m => new MonsterDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Type = m.Type,
                    Hp = m.Hp,
                    Attack = m.Attack,
                    MoveSpeed = m.MoveSpeed,
                    ExpReward = m.ExpReward,
                    Description = m.Description,
                    IconUrl = m.IconUrl
                })
                .ToListAsync();

            return CreatePagedResult(items, pagination, totalCount);
        }

        public async Task<MonsterDto?> GetByIdAsync(int id)
        {
            return await _context.Monsters
                .AsNoTracking()
                .Where(m => m.Id == id)
                .Select(m => new MonsterDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Type = m.Type,
                    Hp = m.Hp,
                    Attack = m.Attack,
                    MoveSpeed = m.MoveSpeed,
                    ExpReward = m.ExpReward,
                    Description = m.Description,
                    IconUrl = m.IconUrl
                })
                .FirstOrDefaultAsync();
        }

        private static IQueryable<Monster> ApplySorting(IQueryable<Monster> query, string? sort)
        {
            return sort?.ToLowerInvariant() switch
            {
                "name_asc" => query.OrderBy(m => m.Name),
                "name_desc" => query.OrderByDescending(m => m.Name),
                "type_asc" => query.OrderBy(m => m.Type).ThenBy(m => m.Id),
                "type_desc" => query.OrderByDescending(m => m.Type).ThenBy(m => m.Id),
                "hp_asc" => query.OrderBy(m => m.Hp).ThenBy(m => m.Id),
                "hp_desc" => query.OrderByDescending(m => m.Hp).ThenBy(m => m.Id),
                "attack_asc" => query.OrderBy(m => m.Attack).ThenBy(m => m.Id),
                "attack_desc" => query.OrderByDescending(m => m.Attack).ThenBy(m => m.Id),
                "movespeed_asc" => query.OrderBy(m => m.MoveSpeed).ThenBy(m => m.Id),
                "movespeed_desc" => query.OrderByDescending(m => m.MoveSpeed).ThenBy(m => m.Id),
                "expreward_asc" => query.OrderBy(m => m.ExpReward).ThenBy(m => m.Id),
                "expreward_desc" => query.OrderByDescending(m => m.ExpReward).ThenBy(m => m.Id),
                "id_desc" => query.OrderByDescending(m => m.Id),
                _ => query.OrderBy(m => m.Id)
            };
        }

        private static PagedResult<MonsterDto> CreatePagedResult(
            List<MonsterDto> items,
            PaginationQuery pagination,
            int totalCount)
        {
            return new PagedResult<MonsterDto>
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
