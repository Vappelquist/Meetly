using Meetly.Data;
using Meetly.DTO;
using Meetly.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meetly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        private readonly IUserService _userservice;

        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpGet("login")]
        public async Task<IActionResult> GetLogin(LoginRequest request) 
        {
            var user = await _userservice.LoginAsync(request.Username, request.Password);
            if(user == null)
            {
                return BadRequest("Invalid username/password Try Again");
            }

            return Ok(user);  
        }

        [HttpPost("create", Name = "CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var result = await _userservice.CreateAsync(request);
            if (result == null)
            {
                return BadRequest("Couldnt Create Account");
            }

            return Ok(result);
        }

    }
}