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
        private readonly IUserService _userservice;

        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetLogin(LoginRequest request) 
        {
            var user = await _userservice.LoginAsync(request.Username, request.Password);
            if(!user.Success)
            {
                return BadRequest("Invalid username/password Try Again");
            }

            return Ok(user.Data);  
        }

        [HttpPost("create", Name = "CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var result = await _userservice.CreateAsync(request);
            if (!result.Success)
            {
                return BadRequest("Couldnt Create Account");
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userservice.GetUserByIdAsync(id);
            if (!result.Success)
            {
                return BadRequest("User not found");
            }

            return Ok(result.Data);
        }

    }
}