using VpGameWeb.Models;
using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Services
{
    public interface IMonsterService
    {
        Task<List<Monster>> GetAllForViewAsync();
        Task<Monster?> GetByIdForViewAsync(int id);
        Task<PagedResult<MonsterDto>> GetAllAsync(string? type, int? minHp, PaginationQuery pagination);
        Task<MonsterDto?> GetByIdAsync(int id);
    }
}
