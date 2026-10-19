using Meetly.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meetly.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly AppDbContext _db;

    public HealthController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Get() => Ok("OK");

    [HttpGet("db")]
    public async Task<IActionResult> CheckDb()
    {
        try
        {
            await _db.Database.OpenConnectionAsync();
            await _db.Database.CloseConnectionAsync();
            return Ok("DB connected");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}