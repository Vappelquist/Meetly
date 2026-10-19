namespace Meetly.Models
{
    public class Meet
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string Place { get;set; }
        public DateTime Time { get; set; }

        public int HostId { get; set; }
        public user Host { get; set; } = null;

        public ICollection<user> Attendes { get; set; }

    }
}
