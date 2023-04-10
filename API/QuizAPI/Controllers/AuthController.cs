using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Services;

namespace QuizAPI.Controllers
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

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _authService.Login(request);
            return StatusCode(response.StatusCode, response.Body);
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _authService.Register(request);
            return StatusCode(response.StatusCode, response.Body);
        }
    }
}
