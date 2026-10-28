using Meetly.DTO;
using Meetly.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        var meetups = await _meetupService.GetMeetupsAsync();

        return Ok(meetups.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MeetupResponse>> GetMeetupById(
        int id
        )
    {
        var meetup = await _meetupService.GetMeetupByIdAsync(id);

        if (meetup is null)
        {
            return NotFound();
        }

        return Ok(meetup);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<MeetupResponse>> CreateMeetup(CreateMeetupRequest request)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdClaim, out var currentUserId))
        {
            return Unauthorized("Invalid user token.");
        }

        var meetup = await _meetupService.CreateMeetupAsync(
            request,
            currentUserId
            );

        if (meetup.Data is null)
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

    [HttpPost("{meetupId}/register/{id}")]
    public async Task<ActionResult> RegisterUserForMeetup(int meetupId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdClaim, out var currentUserId))
        {
            return Unauthorized("Invalid user token.");
        }

        var result = await _meetupService.RegisterMeetAsync(meetupId, currentUserId);
        if (!result.Success)
        {
            return BadRequest("Couldnt register user for the meetup.");
        }
        return Ok("Successfully registered user for the meetup.");
    }

    [Authorize]
    [HttpDelete("{meetupId:int}/register")]
    public async Task<IActionResult> CancelAttendance(int meetupId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdClaim, out var currentUserId))
        {
            return Unauthorized("Invalid user token.");
        }

        var result = await _meetupService.CancelAttendanceAsync(meetupId, currentUserId);

        if (!result.Success)
        {
            return BadRequest(new { message = result.ErrorMessage });
        }

        return NoContent();
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult> DeleteMeetup(int Id)
    {
        var result = await _meetupService.DeleteMeetupAsync(Id);
        if (!result.Success)
        {
            return BadRequest("Couldnt delete the meetup.");
        }
        return Ok("Successfully deleted the meetup.");
    }
}