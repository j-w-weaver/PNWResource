using Microsoft.EntityFrameworkCore;
using PNWResource.API.Data;
using PNWResource.API.Entities;
using PNWResource.API.Models;

namespace PNWResource.API.Services
{
    public class PNWResourceService : IPNWResourceService
    {
        private readonly PNWResourceDbContext context;

        public PNWResourceService(PNWResourceDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<City?>> GetCitiesAsync()
        {
            return await context.Cities.ToListAsync();
        }

        public async Task<City?> GetCityAsync(int cityId, bool includeEvents)
        {
            if (includeEvents)
            {
                return await context.Cities
                .Include(c => c.Events)
                .FirstOrDefaultAsync(c => c.Id == cityId);
            }
            return await context.Cities.FirstOrDefaultAsync(c => c.Id == cityId);
        }

        public async Task<IEnumerable<Event?>> GetCityEventsAsync(int cityId)
        {
            return await context.Events.Where(p => p.CityId == cityId).ToListAsync();
        }

        public async Task<Event?> GetCityEventAsync(int cityId, int eventId)
        {
            //var cityEvent = await context.Events
            //    .Where(e => e.CityId == cityId && e.Id == eventId)
            //    .FirstOrDefaultAsync();
            return await context.Events
                .FirstOrDefaultAsync(e => e.CityId == cityId && e.Id == eventId);
        }

        public async Task AddCity(CityToAddDTO cityToAdd)
        {
            var city = new City
            {
                Name = cityToAdd.Name,
                State = cityToAdd.State,
            };

            await context.Cities.AddAsync(city);
            await context.SaveChangesAsync();
        }

        public async Task<bool> CityExists(int cityId)
        {
            return await context.Cities.AnyAsync(c => c.Id == cityId);
        }

        public async Task AddEventForCity(int cityId, Event eventToAdd)
        {
            var city = await GetCityAsync(cityId, false);
            if (city != null)
            {
                city.Events!.Add(eventToAdd);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() >= 0);
        }
    }
}
