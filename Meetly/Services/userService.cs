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
