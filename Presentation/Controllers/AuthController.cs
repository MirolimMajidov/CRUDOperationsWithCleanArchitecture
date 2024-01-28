using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        protected readonly IUserService _service;
        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string username, string password)
        {
            User user = await _service.GetByUsernameAndPasswordAsync(username, password);
            if (user is null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var accessToken = _service.Authorize(user);
            return Ok(accessToken);
        }
    }
}