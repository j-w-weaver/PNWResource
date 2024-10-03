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

    public CitiesController(IPNWResourceService resourceService)
    {
        this.resourceService = resourceService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities()
    {
        var cities = await resourceService.GetCitiesAsync();
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<City>> GetCity(int id, bool includeEvents)
    {
        var city = await resourceService.GetCityAsync(id, includeEvents);

        if (city == null)
        {
            return NotFound();
        }

        return Ok(city);
    }
}
