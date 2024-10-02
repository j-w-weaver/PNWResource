using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PNWResource.API.Entities;
using PNWResource.API.Models;
using PNWResource.API.Services;
using System.Security.Cryptography.X509Certificates;

namespace PNWResource.API.Controllers
{
    [Route("api/cities/{cityId}/playground")]
    [ApiController]
    public class PlaygroundController : ControllerBase
    {
        //private readonly ILogger<PlaygroundController> logger;
        //private readonly LocalMailService mailService;

        //public PlaygroundController(ILogger<PlaygroundController> logger, LocalMailService mailService)
        //{
        //    this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //    this.mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<PlaygroundDTO>> GetCityPlaygrounds(int cityId)
        //{
        //    try
        //    {
        //        var city = Helpers.GetCity(cityId);

        //        if (city == null)
        //        {
        //            logger.LogInformation($"City with the id: {cityId}, doesn't exist.");
        //            return NotFound("City was not found.");
        //        }

        //        return Ok(city.Playgrounds);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogCritical($"Exception getting city id : {cityId}");
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet("{playgroundId}", Name = "GetPlayground")]
        //public ActionResult<PlaygroundDTO> GetPlayground(int cityId, int playgroundId)
        //{
        //    try
        //    {
        //        var city = Helpers.GetCity(cityId);

        //        if (city == null)
        //        {
        //            return NotFound("City was not found.");
        //        }

        //        var playground = city.Playgrounds.FirstOrDefault(p => p.Id == playgroundId);

        //        if (playground == null)
        //        {
        //            return NotFound("Playground not found.");
        //        }

        //        return Ok(playground);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult<PlaygroundDTO> CreatePlayground(PlaygroundForCreationDTO playground,
        //     int cityId)
        //{
        //    var city = Helpers.GetCity(cityId);

        //    if(city == null)
        //    {
        //        return NotFound();
        //    }

        //    var maxPointOfInterestId = CitiesDataStore.Current.Cities
        //        .SelectMany(c => c.Playgrounds)
        //        .Max(p => p.Id);

        //    var finalPlayground = new PlaygroundDTO
        //    {
        //        Id = ++maxPointOfInterestId,
        //        Name = playground.Name,
        //        Description = playground.Description ?? string.Empty
        //    };

        //    city.Playgrounds.Add(finalPlayground);

        //    return CreatedAtRoute("GetPlayground", new
        //    {
        //        CityId = cityId,
        //        playgroundId = finalPlayground.Id
        //    },
        //    finalPlayground);
        //}

        //[HttpPut("{playgroundId}")]
        //public ActionResult UpdatePlayground(int cityId, int playgroundId, PlaygroundForUpdateDTO playgroundForUpdate)
        //{
        //    var city = Helpers.GetCity(cityId);

        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    var playground = city.Playgrounds.FirstOrDefault(p => p.Id == playgroundId);

        //    if(playground == null)
        //    {
        //        return NotFound();
        //    }

        //    playground.Name = playgroundForUpdate.Name;
        //    playground.Description = playgroundForUpdate.Description ?? string.Empty;

        //    return NoContent();
        //}

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

        //    var playgroundToPatch = new PlaygroundForUpdateDTO
        //    {
        //        Name = playground.Name,
        //        Description = playground.Description,
        //    };

        //    jsonPatchDocument.ApplyTo(playgroundToPatch, ModelState);

        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!TryValidateModel(playgroundToPatch))
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    playground.Name = playgroundToPatch.Name;
        //    playground.Description = playgroundToPatch.Description;

        //    return NoContent();
        //}

        //[HttpDelete("{playgroundId}")]
        //public ActionResult DeletePlayground(int cityId, int playgroundId)
        //{
        //    var city = Helpers.GetCity(cityId);
        //    var playground = city!.Playgrounds.FirstOrDefault(p => p.Id == playgroundId);

        //    city.Playgrounds.Remove(playground!);

        //    mailService.SendMail($"Playground deleted.", $"Playground: {playground.Name} has been deleted from {city.Name}.");

        //    return NoContent();
        //}
    }    
}
