using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PNWResource.API.Entities;
using PNWResource.API.Models;
using PNWResource.API.Services;

namespace PNWResource.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly IPNWResourceService resourceService;
    private readonly IMapper mapper;

    public CitiesController(IPNWResourceService resourceService, IMapper mapper)
    {
        this.resourceService = resourceService;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities()
    {
        var cityEntities = await resourceService.GetCitiesAsync();
        return Ok(mapper.Map<IEnumerable<CityDTO>>(cityEntities));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCity(int id, bool includeEvents = false)
    {
        var city = await resourceService.GetCityAsync(id, includeEvents);

        if (city == null)
        {
            return NotFound();
        }

        if (includeEvents)
        {
            return Ok(mapper.Map<CityWithEventsDTO>(city));
        } 

        return Ok(mapper.Map<CityDTO>(city));
    }
}
