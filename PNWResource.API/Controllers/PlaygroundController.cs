using Microsoft.AspNetCore.Mvc;
using PNWResource.API.Models;

namespace PNWResource.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaygroundController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PlaygroundDTO>> GetAllPlaygrounds()
        {
            var allPlaygrounds = CitiesDataStore.Current.Cities
                .SelectMany(x => x.Playgrounds)
                .ToList();

            return Ok(allPlaygrounds);
        }

        [HttpGet("{id}")]
        public ActionResult<PlaygroundDTO> GetPlayground(int id)
        {
            var allPlaygrounds = CitiesDataStore.Current.Cities
                .SelectMany(x => x.Playgrounds)
                .ToList();

            var playground = allPlaygrounds.FirstOrDefault(x => x.Id == id);

            return Ok(playground);
        }

        [HttpGet("cities/{cityId}")]
        public ActionResult<List<PlaygroundDTO>> GetCityPlaygrounds(int cityId)
        {
            var cityPlaygrounds = CitiesDataStore.Current.Cities
                .Where(x => x.Id == cityId)
                .Select(x => x.Playgrounds)
                .ToList();
            return Ok(cityPlaygrounds);
        }
    }
}
