using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PNWResource.API.Data;
using PNWResource.API.Entities;
using PNWResource.API.Models;
using PNWResource.API.Services;

namespace PNWResource.API.Controllers;

[ApiController]
[Route("api/cities/{cityId}/events")]
public class EventsController : ControllerBase
{
    private readonly IPNWResourceService resourceService;
    private readonly ILogger<PlaygroundController> logger;
    private readonly IMapper mapper;

    public EventsController(IPNWResourceService resourceService, ILogger<PlaygroundController> logger, IMapper mapper)
    {
        this.resourceService = resourceService;
        this.logger = logger;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetCityEvents(int cityId)
    {
        if (!await resourceService.CityExists(cityId))
        {
            logger.LogInformation($"City with ID: {cityId} was not found.");
            return NotFound();
        }
        var cityEvents = await resourceService.GetCityEventsAsync(cityId);

        return Ok(mapper.Map<IEnumerable<EventDTO>>(cityEvents));
    }
    
    [HttpGet("{eventId}", Name = "GetCityEvent")]
    public async Task<ActionResult<EventDTO>> GetCityEvent(int cityId, int eventId)
    {
        if (!await resourceService.CityExists(cityId))
        {
            logger.LogInformation($"City with ID: {cityId} was not found.");
            return NotFound();
        }
        var cityEvent = await resourceService.GetCityEventAsync(cityId, eventId);
        if (cityEvent == null)
        {
            return NotFound();
        }

        return Ok(cityEvent);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCityEvent(int cityId, EventToAddDTO eventDTO)
    {
        if (!await resourceService.CityExists(cityId))
        {
            logger.LogInformation($"City with ID: {cityId} was not found.");
            return NotFound();
        }

        var mappedEventToAdd = mapper.Map<Event>(eventDTO);

        await resourceService.AddEventForCity(cityId, mappedEventToAdd);

        await resourceService.SaveChangesAsync();

        var createdEventForCityToReturn = mapper.Map<EventDTO>(mappedEventToAdd);

        return CreatedAtRoute("GetCityEvent", new
        {
            cityId = cityId,
            eventId = createdEventForCityToReturn.Id
        },
        createdEventForCityToReturn);
    }
}
