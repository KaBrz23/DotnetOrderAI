using DotnetOrderAI.Dtos;
using DotnetOrderAI.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterDto request)
        {
            return await _authService.RegisterAsync(request);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto request)
        {
            return await _authService.LoginAsync(request);
        }
    }
}
