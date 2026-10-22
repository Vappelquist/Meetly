using System.ComponentModel.DataAnnotations;

namespace Meetly.DTO
{
    public record MeetupResponse
    (
         int Id,
         string Title,
         string Description,
         string Place,
         DateTime Time,
         int MaxCapacity,
         int HostId,
         string Host
    );

    public record CreateMeetupRequest(
        [Required]
        string Title,
        [Required]
        string Description,
        [Required]
        string Place,
        [Required]
        DateTime? Time,
        [Range(1, int.MaxValue)]
        int MaxCapacity,
        // Tillfälligt input för att identifiera host
        [Range(1, int.MaxValue)]
        int HostId
    );

}
