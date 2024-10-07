﻿using AutoMapper;
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
    const int maxPageSize = 20;

    public CitiesController(IPNWResourceService resourceService, IMapper mapper)
    {
        this.resourceService = resourceService;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities(string? name, string? searchQuery,
        int pageNumber = 1, int pageSize = 10)
    {
        if (pageNumber > maxPageSize)
        {
            pageSize = maxPageSize;
        }
        var cityEntities = await resourceService.GetCitiesAsync(name, searchQuery, pageNumber, pageSize);
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

    [HttpPost]
    public async Task<ActionResult> AddCity(CityToAddDTO cityToAdd)
    {
        await resourceService.AddCity(cityToAdd);

        return NoContent();
    }
}
