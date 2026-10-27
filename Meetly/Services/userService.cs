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

        public async Task<ServiceResult<LoginResponse?>> LoginAsync(string username, string password)
        {
            var user = await _ctx.User.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                return ServiceResult<LoginResponse?>.Fail("User not found.");
            }
            else if (user.PasswordHash != password)
            {
                return ServiceResult<LoginResponse?>.Fail("Invalid password.");
            }

            return ServiceResult<LoginResponse?>.Ok(new LoginResponse
            (
                user.UserName,
                user.Id
            ));
        }

        public async Task<ServiceResult<CreateUserResponse>> CreateAsync(CreateUserRequest request)
        {
            var newUser = new user
            {
                UserName = request.name,
                PasswordHash = request.password
            };

            if (await _ctx.User.AnyAsync(u => u.UserName == request.name))
            {
                return ServiceResult<CreateUserResponse>.Fail("User already exists.");
            }
            if (string.IsNullOrEmpty(request.name.Trim()) || string.IsNullOrEmpty(request.password.Trim()))
            {
                return ServiceResult<CreateUserResponse>.Fail("Name and password cannot be empty.");
            }
            else if (request.password.Length < 5)
            {
                return ServiceResult<CreateUserResponse>.Fail("Password must be at least 5 characters long.");
            }
            else if (request.password.Any(char.IsWhiteSpace) || request.name.Any(char.IsWhiteSpace))
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

        public async Task<ServiceResult<GetUserByIdResponse?>> GetUserByIdAsync(int userId)
        {
            var user = await _ctx.User.Include(u => u.AttendingMeets).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return ServiceResult<GetUserByIdResponse?>.Fail("User not found.");
            }

            var meets = user.AttendingMeets.Select(m => new UserMeets(
                m.Id,
                m.title,
                m.description,
                m.Place,
                m.Time,
                m.maxCapacity
            )).ToList();

            return ServiceResult<GetUserByIdResponse?>.Ok(new GetUserByIdResponse(
                user.Id,
                user.UserName,
                meets
            ));
        }
    }
}
