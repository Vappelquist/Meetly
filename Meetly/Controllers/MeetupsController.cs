using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Meetly.Data;
using Meetly.DTO;
using Meetly.Models;
using Microsoft.IdentityModel.Tokens;

namespace Meetly.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class MeetupsController : ControllerBase
    {
            private readonly AppDbContext _db;

            public MeetupsController(AppDbContext db)
            {
                _db = db;
            }
    
        [HttpGet]
        public async Task<ActionResult<List<MeetupResponse>>> GetMeetups(
            CancellationToken cancellationToken)
    {
        var meetups = await _db.Set<Meet>()
            .OrderBy(meet => meet.Time)
            .ThenBy(meet => meet.Id)
            .Select(meet => new MeetupResponse
            {
                Id = meet.Id,
                Title = meet.title,
                Description = meet.description,
                Place = meet.Place,
                Time = meet.Time,
                MaxCapacity = meet.maxCapacity
            })
        .ToListAsync(cancellationToken);

        return Ok(meetups);
    
    }
}
