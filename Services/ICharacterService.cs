using VpGameWeb.Models;
using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Services
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllForViewAsync();
        Task<Character?> GetByIdForViewAsync(int id);
        Task<Character> CreateAsync(CharacterCreateViewModel vm);
        Task<PagedResult<CharacterDto>> GetAllAsync(string? race, int? minHp, PaginationQuery pagination);
        Task<CharacterDto?> GetByIdAsync(int id);
    }
}
