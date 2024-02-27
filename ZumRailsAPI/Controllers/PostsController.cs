using Microsoft.AspNetCore.Mvc;
using ZumRailsAPI.Interfaces;
using ZumRailsAPI.Models;

namespace ZumRailsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly ILogger<PostsController> logger;
    private readonly IZumRailsService zumRailsService;

    public PostsController(ILogger<PostsController> logger, IZumRailsService _zumRailsService)
    {
        this.logger = logger;
        this.zumRailsService = _zumRailsService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMembersAsync([FromQuery] string? tags, [FromQuery] string? sortBy,
        [FromQuery] string? direction)
    {
        try
        {
            var result = await zumRailsService.GetPosts(tags, sortBy, direction);

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogInformation(ex.StackTrace, ex.Message);

            return BadRequest(ex.Message);
        }
    }
}

