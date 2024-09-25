using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PNWResource.API.Entities;
using PNWResource.API.Models;
using System.Security.Cryptography.X509Certificates;

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

        [HttpGet("{playgroundId}", Name = "GetPlayground")]
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

        [HttpPost]
        public ActionResult<PlaygroundDTO> CreatePlayground(PlaygroundForCreationDTO playground,
             int cityId)
        {
            var city = Helpers.GetCity(cityId);

            if(city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities
                .SelectMany(c => c.Playgrounds)
                .Max(p => p.Id);

            var finalPlayground = new PlaygroundDTO
            {
                Id = ++maxPointOfInterestId,
                Name = playground.Name,
                Description = playground.Description ?? string.Empty
            };

            city.Playgrounds.Add(finalPlayground);

            return CreatedAtRoute("GetPlayground", new
            {
                CityId = cityId,
                playgroundId = finalPlayground.Id
            },
            finalPlayground);
        }

        [HttpPut("{playgroundId}")]
        public ActionResult UpdatePlayground(int cityId, int playgroundId, PlaygroundForUpdateDTO playgroundForUpdate)
        {
            var city = Helpers.GetCity(cityId);

            if (city == null)
            {
                return NotFound();
            }

            var playground = city.Playgrounds.FirstOrDefault(p => p.Id == playgroundId);

            if(playground == null)
            {
                return NotFound();
            }

            playground.Name = playgroundForUpdate.Name;
            playground.Description = playgroundForUpdate.Description ?? string.Empty;

            return NoContent();
        }

        //[HttpPatch("{playgroundId}")]
        //public ActionResult PartiallyUpdatePlayground(int cityId, int playgroundId,
        //    JsonPatchDocument<PlaygroundForUpdateDTO> jsonPatchDocument)
        //{
        //    var city = Helpers.GetCity(cityId);

        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    var playground = city.Playgrounds.FirstOrDefault(p => p.Id == playgroundId);

        //    if (playground == null)
        //    {
        //        return NotFound();
        //    }

             
        //}
    }    
}
