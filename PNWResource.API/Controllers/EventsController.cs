using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PNWResource.API.Data;
using PNWResource.API.Entities;
using PNWResource.API.Models;
using PNWResource.API.Services;

namespace PNWResource.API.Controllers;

[Route("api/cities/{cityId}/events")]
[Authorize]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IPNWResourceService resourceService;
    private readonly ILogger<PlaygroundController> logger;
    private readonly IMapper mapper;

    public EventsController(IPNWResourceService resourceService, ILogger<PlaygroundController> logger, IMapper mapper)
    {
        this.resourceService = resourceService ?? throw new ArgumentNullException(nameof(resourceService));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetCityEvents(int cityId)
    {
        if (!await resourceService.CityExistsAsync(cityId))
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
        if (!await resourceService.CityExistsAsync(cityId))
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
        if (!await resourceService.CityExistsAsync(cityId))
        {
            logger.LogInformation($"City with ID: {cityId} was not found.");
            return NotFound();
        }

        var mappedEventToAdd = mapper.Map<Event>(eventDTO);

        await resourceService.AddEventForCityAsync(cityId, mappedEventToAdd);

        await resourceService.SaveChangesAsync();

        var createdEventForCityToReturn = mapper.Map<EventDTO>(mappedEventToAdd);

        return CreatedAtRoute("GetCityEvent", new
        {
            cityId = cityId,
            eventId = createdEventForCityToReturn.Id
        },
        createdEventForCityToReturn);
    }

    [HttpPut("{eventId}")]
    public async Task<ActionResult> UpdateCityEvent(int cityId, int eventId, 
        EventToUpdateDTO eventToUpdate)
    {
        if (!await resourceService.CityExistsAsync(cityId))
        {
            return NotFound($"City with the id: {cityId} was not found.");
        }

        var eventEntity = await resourceService.GetCityEventAsync(cityId, eventId);

        if (eventEntity == null)
        {
            return NotFound("not found.");
        }
        
        mapper.Map(eventToUpdate, eventEntity);
        try
        {
            await resourceService.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception)
        {

            throw;
        }
        
    }

    [HttpPatch("{eventId}")]
    public async Task<ActionResult> PatchCityEvent(int cityId, int eventId, 
        JsonPatchDocument<EventToUpdateDTO> patchDocument)
    {
        if (!await resourceService.CityExistsAsync(cityId))
        {
            return NotFound();
        }

        var eventEntity = await resourceService.GetCityEventAsync(cityId, eventId);
        if (eventEntity == null)
        {
            return NotFound();
        }

        var eventToPatch = mapper.Map<EventToUpdateDTO>(eventEntity);
        patchDocument.ApplyTo(eventToPatch);

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!TryValidateModel(eventToPatch))
        {
            return BadRequest();
        }

        mapper.Map(eventToPatch, eventEntity);
        await resourceService.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{eventId}")]
    public async Task<ActionResult> DeleteEvent(int cityId, int eventId)
    {
        if (!await resourceService.CityExistsAsync(cityId))
        {
            return NotFound();
        }

        var eventEntity = await resourceService.GetCityEventAsync(cityId, eventId);
        if (eventEntity == null)
        {
            return NotFound();
        }

        resourceService.DeleteCityEventAsync(eventEntity);

        logger.LogWarning($"City event: {eventEntity.Name} ahs been deleted.");

        return NoContent();
    }
}
