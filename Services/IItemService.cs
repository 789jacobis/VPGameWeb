using VpGameWeb.Models;
using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAllForViewAsync();
        Task<Item?> GetByIdForViewAsync(int id);
        Task<PagedResult<ItemDto>> GetAllAsync(string? category, PaginationQuery pagination);
        Task<ItemDto?> GetByIdAsync(int id);
    }
}
