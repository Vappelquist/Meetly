using Meetly.DTO;
using Meetly.Services;
using Microsoft.AspNetCore.Mvc;

namespace Meetly.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetupsController : ControllerBase
{
    private readonly MeetupService _meetupService;

    public MeetupsController(MeetupService meetupService)
    {
        _meetupService = meetupService;
    }

    [HttpGet]
    public async Task<ActionResult<List<MeetupResponse>>> GetMeetups(
        CancellationToken cancellationToken)
    {
        var meetups = await _meetupService.GetMeetupsAsync(
            cancellationToken);

        return Ok(meetups);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MeetupResponse>> GetMeetupById(
        int id,
        CancellationToken cancellationToken)
    {
        var meetup = await _meetupService.GetMeetupByIdAsync(
            id,
            cancellationToken);

        if (meetup is null)
        {
            return NotFound();
        }

        return Ok(meetup);
    }
}