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
            var meetups = await _db.Set<Meet>()
                .OrderBy(meet => meet.Time)
                .ThenBy(meet => meet.Id)
                .Select(meet => new MeetupResponse(
                    meet.Id,
                    meet.title,
                    meet.description,
                    meet.Place,
                    meet.Time,
                    meet.maxCapacity,
                    meet.HostId,
                    meet.Host.Name,
                    meet.ImageUrl
                ))
                .ToListAsync(cancellationToken);

            return ServiceResult<List<MeetupResponse>>.Ok(meetups);
        }

        public async Task<MeetupResponse?> GetMeetupByIdAsync(
            int id,
            CancellationToken cancellationToken)
        {
            return await _db.Set<Meet>()
                .Where(meet => meet.Id == id)
                .Select(meet => new MeetupResponse(
                    meet.Id,
                    meet.title,
                    meet.description,
                    meet.Place,
                    meet.Time,
                    meet.maxCapacity,
                    meet.HostId,
                    meet.Host.Name,
                    meet.ImageUrl
                ))
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

            var host = await _db.Set<user>()
                .SingleOrDefaultAsync(
                    user => user.Id == request.HostId,
                    cancellationToken);

            if (host is null)
            {
                return ServiceResult<MeetupResponse?>.Fail("Couldnt find host");
            }

            var meetup = new Meet
            {
                title = request.Title.Trim(),
                description = request.Description.Trim(),
                Place = request.Place.Trim(),
                Time = request.Time.Value,
                maxCapacity = request.MaxCapacity,
                HostId = host.Id,
                ImageUrl= request.ImageUrl.Trim(),
                Attendes = new List<user>()
            };

            _db.Set<Meet>().Add(meetup);
            await _db.SaveChangesAsync(cancellationToken);

            return ServiceResult<MeetupResponse?>.Ok(new MeetupResponse(
                meetup.Id,
                meetup.title,
                meetup.description,
                meetup.Place,
                meetup.Time,
                meetup.maxCapacity,
                host.Id,
                host.Name,
                meetup.ImageUrl
            ));
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
                .Select(meet => new MeetupResponse(
                    meet.Id,
                    meet.title,
                    meet.description,
                    meet.Place,
                    meet.Time,
                    meet.maxCapacity,
                    meet.HostId,
                    meet.Host.Name,
                    meet.ImageUrl
                ))
                .ToListAsync();
        }

        public async Task<ServiceResult<bool>> RegisterMeetAsync(int meetupId, int userId)
        {
            var meetup = await _db.Set<Meet>()
                .Include(m => m.Attendes)
                .FirstOrDefaultAsync(m => m.Id == meetupId);

            if (meetup is null)
            {
                return ServiceResult<bool>.Fail("Meetup not found");
            }

            var user = await _db.Set<user>().FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null)
            {
                return ServiceResult<bool>.Fail("User not found");
            }

            if (meetup.Attendes.Any(a => a.Id == userId))
            {
                return ServiceResult<bool>.Fail("User is already registered for this meetup");
            }

            meetup.Attendes.Add(user);
            await _db.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true);
        }

        public async Task<ServiceResult<bool>> CancelAttendanceAsync(
            int meetupId,
            int userId)
        {
            var meetup = await _db.Set<Meet>()
                .Include(m => m.Attendes)
                .FirstOrDefaultAsync(m => m.Id == meetupId);
                }
        public async Task<ServiceResult<bool>> DeleteMeetupAsync(int Id)
        {
            var meetup = await _db.Set<Meet>()
                .FirstOrDefaultAsync(m => m.Id == Id);

            if (meetup is null)
            {
                return ServiceResult<bool>.Fail("Meetup not found");
            }

            var attendee = meetup.Attendes
                .FirstOrDefault(a => a.Id == userId);

            if (attendee is null)
            {
                return ServiceResult<bool>.Fail(
                    "User is not registered for this meetup");
            }

            meetup.Attendes.Remove(attendee);

            _db.Set<Meet>().Remove(meetup);
            await _db.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true);
        }

    }
}
