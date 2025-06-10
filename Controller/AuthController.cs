using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nycformweb.DTOs;
using nycformweb.Helpers;
using nycformweb.Services;

namespace nycformweb.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(PortalUserService portalUserService, IConfiguration config) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {

            var user = await portalUserService.AuthenticateAsync(request.username, request.password);

            if (user == null)
                return Unauthorized("Invalid credentials.");

            var token = JwtTokenHelper.GenerateToken(user.Username, user.Role, config);

            return Ok(new { token, user.Username, user.Role });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logged out. Please delete token on client." });
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var registration = await portalUserService.GetAllAsync();

            return Ok(registration);
        }

        [HttpGet("GetVersion")]
        public async Task<IActionResult> GetVersion()
        {
            return Ok("1.0");
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] PortalUserDtoToCreate portalUser)
        {
            if (portalUser == null)
                return BadRequest("Invalid user data.");

            var existingUser = await portalUserService.GetUserByUsernameAsync(portalUser.Username);
            if (existingUser != null)
                return Conflict("User with this username already exists.");

            var userToCreate = new Models.PortalUser
            {
                Username = portalUser.Username,
                Password = portalUser.Password,
                Role = portalUser.Role
            };

            var created = await portalUserService.CreateAsync(userToCreate);

            return created != null
                ? Ok(created)
                : BadRequest();
        }
    }
}