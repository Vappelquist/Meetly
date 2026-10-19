namespace Meetly.DTO
{
    public class MeetupResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime Time { get; set; }
        public int MaxCapacity { get; set; }
    }
}
