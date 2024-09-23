using Microsoft.AspNetCore.Mvc;
using PNWResource.API.Models;

namespace PNWResource.API.Controllers
{
    [Route("api/cities/{cityId}/playground")]
    [ApiController]
    public class PlaygroundController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PlaygroundDTO>> GetCityPlaygrounds(int cityId)
        {
            var city = Helpers.GetCity(cityId);

            if (city == null)
            {
                return NotFound("City was not found.");
            }

            return Ok(city.Playgrounds);
        }

        [HttpGet("{playgroundId}")]
        public ActionResult<PlaygroundDTO> GetPlayground(int cityId, int playgroundId)
        {
            var city = Helpers.GetCity(cityId);

            if (city == null)
            {
                return NotFound("City was not found.");
            }

            var playground = city.Playgrounds.FirstOrDefault(p => p.Id == playgroundId);

            if (playground == null)
            {
                return NotFound("Playground not found.");
            }

            return Ok(playground);
        }
    }    
}
