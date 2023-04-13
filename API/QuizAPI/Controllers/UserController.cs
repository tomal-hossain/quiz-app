using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        [HttpGet, Route("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            return Ok(CurrentUser);
        }
    }
}
