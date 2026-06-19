using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models.Dtos;
using VpGameWeb.Services;

namespace VpGameWeb.Controllers.Api
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterApiController : ControllerBase
    {
        private readonly ICharacterService _service;
        private readonly ILogger<CharacterApiController> _logger;

        public CharacterApiController(
            ICharacterService service,
            ILogger<CharacterApiController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Gets a paged list of characters.
        /// </summary>
        /// <remarks>
        /// Supports race, minimum HP, pagination, and sorting. Sort examples: name_asc, hp_desc, attack_desc.
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<CharacterDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            string? race,
            int? minHp,
            [FromQuery] PaginationQuery pagination)
        {
            _logger.LogInformation(
                "Fetching characters with race {Race}, minHp {MinHp}, page {Page}, pageSize {PageSize}.",
                race,
                minHp,
                pagination.Page,
                pagination.PageSize);

            PagedResult<CharacterDto> characters = await _service.GetAllAsync(race, minHp, pagination);

            return Ok(ApiResponse<PagedResult<CharacterDto>>.Ok(characters));
        }

        /// <summary>
        /// Gets one character by id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<CharacterDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<CharacterDto>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            CharacterDto? character = await _service.GetByIdAsync(id);

            if (character == null)
            {
                _logger.LogWarning("Character {CharacterId} was not found.", id);
                return NotFound(ApiResponse<CharacterDto>.Fail("Character not found."));
            }

            return Ok(ApiResponse<CharacterDto>.Ok(character));
        }
    }
}
