using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Services;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost, Route("create-quiz")]
        public async Task<IActionResult> CreateQuiz(QuizDto quiz)
        {
            var result = await _adminService.CreateQuiz(quiz);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest("Something went wrong");
        }

        [HttpGet, Route("quiz-list")]
        public async Task<IActionResult> GetQuizes()
        {
            var result = await _adminService.GetQuizes();
            return Ok(result);
        }
    }
}
