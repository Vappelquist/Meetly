using System.ComponentModel.DataAnnotations;


namespace Meetly.DTO
{
    public class CreateMeetupRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Place { get; set; } = string.Empty;
        [Required]
        public DateTime? Time { get; set; }
        [Range(1, int.MaxValue)]
        public int MaxCapacity { get; set; }

        // Tillfälligt input för att identifiera host
        [Range(1, int.MaxValue)]
        public int HostId { get; set; }
    }
}
