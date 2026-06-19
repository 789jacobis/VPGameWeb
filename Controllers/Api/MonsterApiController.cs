using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models.Dtos;
using VpGameWeb.Services;

namespace VpGameWeb.Controllers.Api
{
    [Route("api/monsters")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Monsters")]
    public class MonsterApiController : ControllerBase
    {
        private readonly IMonsterService _service;
        private readonly ILogger<MonsterApiController> _logger;

        public MonsterApiController(
            IMonsterService service,
            ILogger<MonsterApiController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Gets a paged list of monsters.
        /// </summary>
        /// <remarks>
        /// Supports type, minimum HP, pagination, and sorting. Sort examples: hp_desc, attack_desc, expreward_desc.
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<MonsterDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            string? type,
            int? minHp,
            [FromQuery] PaginationQuery pagination)
        {
            _logger.LogInformation(
                "Fetching monsters with type {Type}, minHp {MinHp}, page {Page}, pageSize {PageSize}.",
                type,
                minHp,
                pagination.Page,
                pagination.PageSize);

            PagedResult<MonsterDto> monsters = await _service.GetAllAsync(type, minHp, pagination);

            return Ok(ApiResponse<PagedResult<MonsterDto>>.Ok(monsters));
        }

        /// <summary>
        /// Gets one monster by id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<MonsterDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<MonsterDto>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            MonsterDto? monster = await _service.GetByIdAsync(id);

            if (monster == null)
            {
                _logger.LogWarning("Monster {MonsterId} was not found.", id);
                return NotFound(ApiResponse<MonsterDto>.Fail("Monster not found."));
            }

            return Ok(ApiResponse<MonsterDto>.Ok(monster));
        }
    }
}
