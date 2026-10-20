using System.ComponentModel.DataAnnotations;

namespace Meetly.Models
{
    public class user
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string PasswordHash { get; set; }



        //nav
        public ICollection<Meet> HostedMeets { get; set; } = new List<Meet>();
        public ICollection<Meet> AttendingMeets { get; set; } = new List<Meet>();
    }
}
