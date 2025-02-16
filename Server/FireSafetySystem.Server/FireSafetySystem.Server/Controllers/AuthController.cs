using FireSafetySystem.Server.Authentication;
using FireSafetySystem.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace FireSafetySystem.Server.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var success = await _authService.Register(request);
            if (!success) return BadRequest("User already exists");
            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _authService.Authenticate(request);
            if (response == null) return Unauthorized("Invalid credentials");
            return Ok(response);
        }
    }
}
