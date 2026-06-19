using VpGameWeb.Models;
using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Services
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllForViewAsync();
        Task<Skill?> GetByIdForViewAsync(int id);
        Task<PagedResult<SkillDto>> GetAllAsync(string? category, PaginationQuery pagination);
        Task<SkillDto?> GetByIdAsync(int id);
    }
}
