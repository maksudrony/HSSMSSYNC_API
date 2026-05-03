using Microsoft.AspNetCore.Mvc;
using HSSMSSYNC_API.Interfaces;

namespace HSSMSSYNC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            try
            {
                var stats = await _service.GetDashboardStatsAsync();
                return Ok(new { success = true, data = stats });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}