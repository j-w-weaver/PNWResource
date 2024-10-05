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

        public async Task<IEnumerable<Event?>> GetAllEventsAsync(int cityId)
        {
            return await context.Events.Where(p => p.CityId == cityId).ToListAsync();
        }

        public async Task<Event?> GetEventAsync(int cityId, int playgroundId)
        {
            return await context.Events
                .Where(p => p.CityId == cityId && p.Id == playgroundId).FirstOrDefaultAsync();
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
    }
}
