using Microsoft.EntityFrameworkCore;

namespace Meetly.Data
{
    public class MeetlyDbContext : DbContext
    {
        public MeetlyDbContext(DbContextOptions<MeetlyDbContext> options) 
            : base(options)
        {
        }
    }
}
