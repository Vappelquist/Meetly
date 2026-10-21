using Meetly.DTO;

namespace Meetly.Services
{
    public interface IMeetupService
    {

        Task<List<MeetupResponse>> GetMeetupsAsync(
            CancellationToken cancellationToken);

        Task<MeetupResponse?> GetMeetupByIdAsync(
            int id,
            CancellationToken cancellationToken);

        Task<MeetupResponse?> CreateMeetupAsync(
            CreateMeetupRequest request,
            CancellationToken cancellationToken);

        Task<List<MeetupResponse>> FindAsync(
            string searchText);
    }
}
