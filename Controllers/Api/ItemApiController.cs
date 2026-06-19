using Microsoft.AspNetCore.Mvc;
using VpGameWeb.Models.Dtos;
using VpGameWeb.Services;

namespace VpGameWeb.Controllers.Api
{
    [Route("api/items")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        private readonly IItemService _service;
        private readonly ILogger<ItemApiController> _logger;

        public ItemApiController(
            IItemService service,
            ILogger<ItemApiController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Gets a paged list of items.
        /// </summary>
        /// <remarks>
        /// Supports category filtering, pagination, and sorting. Sort examples: name_asc, category_desc.
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<ItemDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            string? category,
            [FromQuery] PaginationQuery pagination)
        {
            _logger.LogInformation(
                "Fetching items with category {Category}, page {Page}, pageSize {PageSize}.",
                category,
                pagination.Page,
                pagination.PageSize);

            PagedResult<ItemDto> items = await _service.GetAllAsync(category, pagination);

            return Ok(ApiResponse<PagedResult<ItemDto>>.Ok(items));
        }

        /// <summary>
        /// Gets one item by id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ItemDto>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ItemDto? item = await _service.GetByIdAsync(id);

            if (item == null)
            {
                _logger.LogWarning("Item {ItemId} was not found.", id);
                return NotFound(ApiResponse<ItemDto>.Fail("Item not found."));
            }

            return Ok(ApiResponse<ItemDto>.Ok(item));
        }
    }
}
