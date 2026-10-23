using Meetly.DTO;
using Meetly.Utils;

namespace Meetly.Services
{
    public interface IMeetupService
    {

        Task<ServiceResult<List<MeetupResponse>>> GetMeetupsAsync(
            CancellationToken cancellationToken);

        Task<MeetupResponse?> GetMeetupByIdAsync(
            int id,
            CancellationToken cancellationToken);

        Task<ServiceResult<MeetupResponse?>> CreateMeetupAsync(
            CreateMeetupRequest request,
            CancellationToken cancellationToken);

        Task<List<MeetupResponse>> FindAsync(
            string searchText);

        Task<ServiceResult<bool>> RegisterMeetAsync(int meetupId, int userId);

        Task<ServiceResult<bool>> CancelAttendanceAsync(
            int meetupId,
            int userId);
    }
}
