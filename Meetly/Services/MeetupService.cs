using Meetly.Data;
using Meetly.DTO;
using Meetly.Models;
using Microsoft.EntityFrameworkCore;

    namespace Meetly.Services
{
    public class MeetupService
    {
        private readonly AppDbContext _db;
        
        public MeetupService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<MeetupResponse>> GetMeetupsAsync(
            CancellationToken cancellationToken)
        {
            return await _db.Set<Meet>()
                .OrderBy(meet => meet.Time)
                .ThenBy(meet => meet.Id)
                .Select(meet => new MeetupResponse
                {
                    Id = meet.Id,
                    Title = meet.title,
                    Description = meet.description,
                    Place = meet.Place,
                    Time = meet.Time,
                    MaxCapacity = meet.maxCapacity,
                    HostId = meet.HostId,
                    Host = meet.Host.Name
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<MeetupResponse?> GetMeetupByIdAsync(
            int id,
            CancellationToken cancellationToken)
        {
            return await _db.Set<Meet>()
                .Where(meet => meet.Id == id)
                .Select(meet => new MeetupResponse
                {
                    Id = meet.Id,
                    Title = meet.title,
                    Description = meet.description,
                    Place = meet.Place,
                    Time = meet.Time,
                    MaxCapacity = meet.maxCapacity,
                    HostId = meet.HostId,
                    Host = meet.Host.Name
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
