using Meetly.Data;
using Meetly.DTO;
using Meetly.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<LoginRequest?> LoginAsync(string username, string password)
        {
            var user = await _ctx.User.FirstOrDefaultAsync(u => u.Name == username);
            if (user == null)
            {
                return null;
            }
            else if(user.PasswordHash != password)
            {
                return null;
            }

            return new LoginRequest
            (
                user.Name,
                user.PasswordHash
            );    
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUserRequest request)
        {
            var newUser = new user
            {
                Name = request.name,
                PasswordHash = request.password
            };

            if (await _ctx.User.AnyAsync(u => u.Name == request.name))
            {
                return null;
            }


            await _ctx.User.AddAsync(newUser);
            await _ctx.SaveChangesAsync();

            return new CreateUserResponse
            (
                request.name,
                newUser.PasswordHash
            );
        }
    }
}
