using Meetly.DTO;
using Meetly.Services;
using Microsoft.AspNetCore.Mvc;

namespace Meetly.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetupsController : ControllerBase
{
    private readonly IMeetupService _meetupService;

    public MeetupsController(IMeetupService meetupService)
    {
        _meetupService = meetupService;
    }

    [HttpGet]
    public async Task<ActionResult<List<MeetupResponse>>> GetMeetups(
        CancellationToken cancellationToken)
    {
        var meetups = await _meetupService.GetMeetupsAsync(
            cancellationToken);

        return Ok(meetups.Data);
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

    [HttpPost]
    public async Task<ActionResult<MeetupResponse>> CreateMeetup(
        [FromBody] CreateMeetupRequest request,
        CancellationToken cancellationToken)
    {
        var meetup = await _meetupService.CreateMeetupAsync(
            request,
            cancellationToken);

        if (meetup is null)
        {
            return BadRequest(new
            {
                message = "The selected host does not exist!"
            });
        }

        return CreatedAtAction(
            nameof(GetMeetupById),
            new { id = meetup.Data.Id },
            meetup.Data);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<MeetupResponse>>> FindMeetupsByKeyword(
    [FromQuery] string? searchText)
    {
        var meetups = await _meetupService.FindAsync(
            searchText ?? string.Empty);

        return Ok(meetups);
    }

    [HttpPost("{meetupId:int}/register/{userId:int}")]
    public async Task<ActionResult> RegisterUserForMeetup(
        int meetupId,
        int userId)
    {
        var result = await _meetupService.RegisterMeetAsync(meetupId, userId);
        if (!result.Success)
        {
            return BadRequest("Couldnt register user for the meetup.");
        }
        return Ok("Successfully registered user for the meetup.");
    }
}