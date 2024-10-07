
using PNWResource.API.Entities;
using PNWResource.API.Models;

namespace PNWResource.API.Services;

public interface IPNWResourceService
{
    Task<IEnumerable<City?>> GetCitiesAsync();
    Task<IEnumerable<City?>> GetCitiesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
    Task<City?> GetCityAsync(int cityId, bool includeEvents);
    Task<IEnumerable<Event?>> GetCityEventsAsync(int cityId);
    Task<Event?> GetCityEventAsync(int cityId, int eventId);
    Task AddEventForCityAsync(int cityId, Event eventToAdd);
    void DeleteCityEventAsync(Event eventToDelete);
    Task<bool> SaveChangesAsync();
    Task<bool> CityExistsAsync(int cityId);
    Task AddCity(CityToAddDTO city);

    //Task<IEnumerable<Playground?>> GetPlaygroundsAsync(int cityId);
    //Task<Playground?> GetPlaygroundAsync(int cityId, int playgroundId);
    //Task<IEnumerable<DaycareCenter?>> GetDaycareCentersAsync(int cityId);
    //Task<DaycareCenter?> GetDaycareCenterAsync(int cityId, int daycareCenterId);
    //Task<IEnumerable<Library?>> GetLibrariesAsync(int cityId);
    //Task<Library?> GetLibraryAsync(int cityId, int libraryId);
}
