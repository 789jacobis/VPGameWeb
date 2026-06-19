using Microsoft.EntityFrameworkCore;
using VpGameWeb.Data;
using VpGameWeb.Models;
using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Services
{
    public class SkillService : ISkillService
    {
        private readonly AppDbContext _context;

        public SkillService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllForViewAsync()
        {
            return await _context.Skills
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Skill?> GetByIdForViewAsync(int id)
        {
            return await _context.Skills
                .AsNoTracking()
                .Include(s => s.Levels)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PagedResult<SkillDto>> GetAllAsync(
            string? category,
            PaginationQuery pagination)
        {
            var query = _context.Skills
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(s => s.Category == category);
            }

            query = ApplySorting(query, pagination.Sort);

            int totalCount = await query.CountAsync();
            List<SkillDto> items = await query
                .Skip(pagination.Skip)
                .Take(pagination.PageSize)
                .Select(s => new SkillDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Category = s.Category,
                    Description = s.Description,
                    IconUrl = s.IconUrl,
                    Levels = s.Levels
                        .OrderBy(l => l.Level)
                        .Select(l => new SkillLevelDto
                        {
                            Id = l.Id,
                            Level = l.Level,
                            Description = l.Description
                        })
                        .ToList()
                })
                .ToListAsync();

            return CreatePagedResult(items, pagination, totalCount);
        }

        public async Task<SkillDto?> GetByIdAsync(int id)
        {
            return await _context.Skills
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SkillDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Category = s.Category,
                    Description = s.Description,
                    IconUrl = s.IconUrl,
                    Levels = s.Levels
                        .OrderBy(l => l.Level)
                        .Select(l => new SkillLevelDto
                        {
                            Id = l.Id,
                            Level = l.Level,
                            Description = l.Description
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        private static IQueryable<Skill> ApplySorting(IQueryable<Skill> query, string? sort)
        {
            return sort?.ToLowerInvariant() switch
            {
                "name_asc" => query.OrderBy(s => s.Name),
                "name_desc" => query.OrderByDescending(s => s.Name),
                "category_asc" => query.OrderBy(s => s.Category).ThenBy(s => s.Id),
                "category_desc" => query.OrderByDescending(s => s.Category).ThenBy(s => s.Id),
                "id_desc" => query.OrderByDescending(s => s.Id),
                _ => query.OrderBy(s => s.Id)
            };
        }

        private static PagedResult<SkillDto> CreatePagedResult(
            List<SkillDto> items,
            PaginationQuery pagination,
            int totalCount)
        {
            return new PagedResult<SkillDto>
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
