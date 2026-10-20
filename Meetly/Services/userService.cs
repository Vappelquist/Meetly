using Meetly.Data;
using Meetly.DTO;
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
            {
                Username = user.Name,
                Password = user.PasswordHash
            };    
        }
    }
}
