using Microsoft.AspNetCore.Mvc;
using PNWResource.API.Models;

namespace PNWResource.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        //[HttpGet]
        //public ActionResult GetCities()
        //{
        //    var cities = CitiesDataStore.Current.Cities;
        //    return Ok(cities);
        //}

        //[HttpGet("{id}")]
        //public ActionResult<CityDTO> GetCity(int id)
        //{
        //    var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(city);
        //}
    }
}
