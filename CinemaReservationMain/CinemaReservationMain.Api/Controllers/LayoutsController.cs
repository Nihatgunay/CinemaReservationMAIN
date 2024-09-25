using CinemaReservationMain.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutsController : ControllerBase
    {
        private readonly ILayoutService _layoutService;

        public LayoutsController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = await _layoutService.GetUser(username);

            if (user == null)
            {
                return NotFound($"username '{username}' not found.");
            }

            return Ok(user);
        }
    }
}
