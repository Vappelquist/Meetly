using Meetly.Data;
using Meetly.DTO;
using Meetly.Models;
using Meetly.Utils;
using Microsoft.EntityFrameworkCore;

    namespace Meetly.Services
{
    public class MeetupService : IMeetupService
    {
        private readonly AppDbContext _db;
        
        public MeetupService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceResult<List<MeetupResponse>>> GetMeetupsAsync(
            CancellationToken cancellationToken)
        {
            return ServiceResult<List<MeetupResponse>>.Ok(await _db.Set<Meet>()
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
                .ToListAsync(cancellationToken));
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

        public async Task<ServiceResult<MeetupResponse?>> CreateMeetupAsync(
            CreateMeetupRequest request,
            CancellationToken cancellationToken)
        {
            if (request.Time is null)
            {
                throw new ArgumentException(
                    "A meetup time is required.",
                    nameof(request));
            }

            var host = await _db.Set<user>().
                SingleOrDefaultAsync(
                user => user.Id == request.HostId,
                cancellationToken);

            if (host is null)
            {
                return ServiceResult<MeetupResponse>.Fail("Couldnt find host");
            }

            var meetup = new Meet
            {
                title = request.Title.Trim(),
                description = request.Description.Trim(),
                Place = request.Place.Trim(),
                Time = request.Time.Value,
                maxCapacity = request.MaxCapacity,
                HostId = host.Id,
                Attendes = new List<user>()
            };

            _db.Set<Meet>().Add(meetup);

            await _db.SaveChangesAsync(cancellationToken);

            return ServiceResult<MeetupResponse?>.Ok(new MeetupResponse
            {
                Id = meetup.Id,
                Title = meetup.title,
                Description = meetup.description,
                Place = meetup.Place,
                Time = meetup.Time,
                MaxCapacity = meetup.maxCapacity
            });
        }

        public async Task<List<MeetupResponse>> FindAsync(string searchText)
        {
            searchText = searchText.Trim();

            return await _db.Set<Meet>()
                .Where(meet =>
                    meet.title.Contains(searchText) ||
                    meet.description.Contains(searchText))
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
                .ToListAsync();
        }
    }
}
