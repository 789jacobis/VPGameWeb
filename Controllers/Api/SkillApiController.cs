using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models.Dtos;
using VpGameWeb.Services;

namespace VpGameWeb.Controllers.Api
{
    [Route("api/skills")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Skills")]
    public class SkillApiController : ControllerBase
    {
        private readonly ISkillService _service;
        private readonly ILogger<SkillApiController> _logger;

        public SkillApiController(
            ISkillService service,
            ILogger<SkillApiController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Gets a paged list of skills.
        /// </summary>
        /// <remarks>
        /// Supports category filtering, pagination, and sorting. Sort examples: name_asc, category_desc.
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<SkillDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            string? category,
            [FromQuery] PaginationQuery pagination)
        {
            _logger.LogInformation(
                "Fetching skills with category {Category}, page {Page}, pageSize {PageSize}.",
                category,
                pagination.Page,
                pagination.PageSize);

            PagedResult<SkillDto> skills = await _service.GetAllAsync(category, pagination);

            return Ok(ApiResponse<PagedResult<SkillDto>>.Ok(skills));
        }

        /// <summary>
        /// Gets one skill by id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<SkillDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<SkillDto>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            SkillDto? skill = await _service.GetByIdAsync(id);

            if (skill == null)
            {
                _logger.LogWarning("Skill {SkillId} was not found.", id);
                return NotFound(ApiResponse<SkillDto>.Fail("Skill not found."));
            }

            return Ok(ApiResponse<SkillDto>.Ok(skill));
        }
    }
}
