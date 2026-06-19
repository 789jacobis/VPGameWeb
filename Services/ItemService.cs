using Microsoft.EntityFrameworkCore;
using VpGameWeb.Data;
using VpGameWeb.Models;
using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Services
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetAllForViewAsync()
        {
            return await _context.Items
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Item?> GetByIdForViewAsync(int id)
        {
            return await _context.Items
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<PagedResult<ItemDto>> GetAllAsync(
            string? category,
            PaginationQuery pagination)
        {
            var query = _context.Items
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(i => i.Category == category);
            }

            query = ApplySorting(query, pagination.Sort);

            int totalCount = await query.CountAsync();
            List<ItemDto> items = await query
                .Skip(pagination.Skip)
                .Take(pagination.PageSize)
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Category = i.Category,
                    Description = i.Description,
                    IconUrl = i.IconUrl
                })
                .ToListAsync();

            return CreatePagedResult(items, pagination, totalCount);
        }

        public async Task<ItemDto?> GetByIdAsync(int id)
        {
            return await _context.Items
                .AsNoTracking()
                .Where(i => i.Id == id)
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Category = i.Category,
                    Description = i.Description,
                    IconUrl = i.IconUrl
                })
                .FirstOrDefaultAsync();
        }

        private static IQueryable<Item> ApplySorting(IQueryable<Item> query, string? sort)
        {
            return sort?.ToLowerInvariant() switch
            {
                "name_asc" => query.OrderBy(i => i.Name),
                "name_desc" => query.OrderByDescending(i => i.Name),
                "category_asc" => query.OrderBy(i => i.Category).ThenBy(i => i.Id),
                "category_desc" => query.OrderByDescending(i => i.Category).ThenBy(i => i.Id),
                "id_desc" => query.OrderByDescending(i => i.Id),
                _ => query.OrderBy(i => i.Id)
            };
        }

        private static PagedResult<ItemDto> CreatePagedResult(
            List<ItemDto> items,
            PaginationQuery pagination,
            int totalCount)
        {
            return new PagedResult<ItemDto>
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
