using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Meetly.Models
{
    public class user : IdentityUser<int>
    {

        //nav
        public ICollection<Meet> HostedMeets { get; set; } = new List<Meet>();
        public ICollection<Meet> AttendingMeets { get; set; } = new List<Meet>();
    }
}
