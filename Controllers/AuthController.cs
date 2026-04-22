using Microsoft.AspNetCore.Mvc;
using HSSMSSYNC_API.DTOs;
using HSSMSSYNC_API.Interfaces;

namespace HSSMSSYNC_API.Controllers
{
    [ApiController] // Tells .NET this is an API, automatically validates routing
    [Route("api/[controller]")] // The route becomes: http://your-ip:port/api/auth
    public class AuthController : ControllerBase
    {
        private readonly IRemoteAccUserService _userService;

        // Inject the Service Layer
        public AuthController(IRemoteAccUserService userService)
        {
            _userService = userService;
        }

        // Expose a POST endpoint for logging in
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Basic validation: Reject empty payloads instantly
            if (request == null || request.EnrollmentId <= 0 || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new LoginResponse { Success = false, Message = "Opps! Invalid Login Request." });
            }

            // Pass to the Service Layer
            var response = await _userService.AuthenticateAsync(request);

            // Return correct HTTP Status Codes based on success
            if (!response.Success)
            {
                return Unauthorized(response); // 401 HTTP Status
            }

            return Ok(response); // 200 HTTP Status
        }
    }
}