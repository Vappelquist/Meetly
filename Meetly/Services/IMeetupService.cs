using Meetly.DTO;
using Meetly.Utils;

namespace Meetly.Services
{
    public interface IMeetupService
    {

        Task<ServiceResult<List<MeetupResponse>>> GetMeetupsAsync(
            CancellationToken cancellationToken);

        Task<MeetupResponse?> GetMeetupByIdAsync(
            int id);

        Task<ServiceResult<MeetupResponse?>> CreateMeetupAsync(
            CreateMeetupRequest request,
            int hostId,
            CancellationToken cancellationToken);

        Task<List<MeetupResponse>> FindAsync(
            string searchText);

        Task<ServiceResult<bool>> RegisterMeetAsync(int meetupId, int userId);

        Task<ServiceResult<bool>> DeleteMeetupAsync(int Id);
        //test
        Task<ServiceResult<bool>> CancelAttendanceAsync(int meetupId, int userId);
    }
}
