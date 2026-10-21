using Meetly.Data;
using Meetly.DTO;
using Meetly.Models;
using Meetly.Utils;
using Microsoft.EntityFrameworkCore;

namespace Meetly.Services
{
    public class userService : IUserService
    {
        private readonly AppDbContext _ctx;

        public userService(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ServiceResult<LoginRequest?>> LoginAsync(string username, string password)
        {
            var user = await _ctx.User.FirstOrDefaultAsync(u => u.Name == username);
            if (user == null)
            {
                return ServiceResult<LoginRequest?>.Fail("User not found.");
            }
            else if(user.PasswordHash != password)
            {
                return ServiceResult<LoginRequest?>.Fail("Invalid password.");
            }

            return ServiceResult<LoginRequest?>.Ok(new LoginRequest
            (
                user.Name,
                user.PasswordHash
            ));    
        }

        public async Task<ServiceResult<CreateUserResponse>> CreateAsync(CreateUserRequest request)
        {
            var newUser = new user
            {
                Name = request.name,
                PasswordHash = request.password
            };

            if (await _ctx.User.AnyAsync(u => u.Name == request.name))
            {
                return ServiceResult<CreateUserResponse>.Fail("User already exists.");
            }
            if(string.IsNullOrEmpty(request.name.Trim()) || string.IsNullOrEmpty(request.password.Trim()))
            {
                return ServiceResult<CreateUserResponse>.Fail("Name and password cannot be empty.");
            }
            else if(request.password.Length < 5)
            {
                return ServiceResult<CreateUserResponse>.Fail("Password must be at least 5 characters long.");
            }
            else if(request.password.Any(char.IsWhiteSpace) || request.name.Any(char.IsWhiteSpace))
            {
                return ServiceResult<CreateUserResponse>.Fail("Name and password cannot contain whitespace.");
            }

            await _ctx.User.AddAsync(newUser);
            await _ctx.SaveChangesAsync();

            return ServiceResult<CreateUserResponse>.Ok(new CreateUserResponse
            (
                request.name,
                newUser.PasswordHash
            ));
        }
    }
}
