using Microsoft.AspNetCore.Mvc;
using PNWResource.API.Entities;
using PNWResource.API.Models;

namespace PNWResource.API.Services
{
    public interface IPNWResourceService
    {
        Task<IEnumerable<City?>> GetCitiesAsync();
        Task<City?> GetCityAsync(int cityId, bool includeEvents);
        Task<IEnumerable<Event?>> GetAllEventsAsync(int cityId);
        Task<Event?> GetEventAsync(int cityId, int eventId);

        //Task<IEnumerable<Playground?>> GetPlaygroundsAsync(int cityId);
        //Task<Playground?> GetPlaygroundAsync(int cityId, int playgroundId);
        //Task<IEnumerable<DaycareCenter?>> GetDaycareCentersAsync(int cityId);
        //Task<DaycareCenter?> GetDaycareCenterAsync(int cityId, int daycareCenterId);
        //Task<IEnumerable<Library?>> GetLibrariesAsync(int cityId);
        //Task<Library?> GetLibraryAsync(int cityId, int libraryId);
    }
}
