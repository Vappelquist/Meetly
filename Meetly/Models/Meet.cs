using System.ComponentModel.DataAnnotations;

namespace Meetly.Models
{
    public class Meet
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string title { get; set; }
        [MaxLength(200)]
        public string description { get; set; }
        [Required, MaxLength(100)]
        public string Place { get;set; }
        public DateTime Time { get; set; }
        public int HostId { get; set; }
        [Required]
        public user Host { get; set; } = null;
        [Required]
        public int maxCapacity { get; set; }

        public ICollection<user> Attendes { get; set; }

    }
}
