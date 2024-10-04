using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PNWResource.API.Data;
using PNWResource.API.Entities;

namespace PNWResource.API.Controllers;

[ApiController]
[Route("api/cities/{cityId}/event")]
public class EventController : ControllerBase
{
    private readonly PNWResourceDbContext context;

    public EventController(PNWResourceDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetCityEvents(int cityId)
    {
        var cityEvents = await context.Events.Where(c => c.CityId == cityId).ToListAsync();
        return Ok(cityEvents);
    }
    
    [HttpGet("{eventId}")]
    public async Task<ActionResult<Event>> GetCityEvent(int cityId, int eventId)
    {
        var cityEvent = await context.Events.FirstOrDefaultAsync(e => e.CityId == cityId && e.Id == eventId);
        if (cityEvent == null)
        {
            return NotFound();
        }

        return Ok(cityEvent);
    }
}
