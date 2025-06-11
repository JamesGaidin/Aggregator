using Aggregator.Models;
using Aggregator.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtTokenService _tokenService;

        public UsersController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            JwtTokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            try
            {
                var user = new AppUser { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return Ok("User registered");

                return BadRequest(result.Errors); // Will return errors like PasswordTooWeak, etc.
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Registration failed: {ex.Message}");
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var token = _tokenService.GenerateToken(user!);
                return Ok(new { token });
            }

            return Unauthorized("Invalid credentials");
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = _userManager.GetUserId(User); // Claims-based ID
            var user = await _userManager.FindByIdAsync(userId!);

            if (user == null)
                return NotFound("User not found.");

            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email
            });
        }

    }

    public class RegisterRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
