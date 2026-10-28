using Meetly.DTO;
using Meetly.Utils;

namespace Meetly.Services
{
    public interface IMeetupService
    {

        Task<ServiceResult<List<MeetupResponse>>> GetMeetupsAsync();

        Task<MeetupResponse?> GetMeetupByIdAsync(int id);

        Task<ServiceResult<MeetupResponse?>> CreateMeetupAsync(CreateMeetupRequest request, int hostId);

        Task<List<MeetupResponse>> FindAsync(
            string searchText);

        Task<ServiceResult<bool>> RegisterMeetAsync(int meetupId, int userId);

        Task<ServiceResult<bool>> DeleteMeetupAsync(int Id);
        
        Task<ServiceResult<bool>> CancelAttendanceAsync(int meetupId, int userId);
    }
}
