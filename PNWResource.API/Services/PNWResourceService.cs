using Microsoft.EntityFrameworkCore;
using PNWResource.API.Data;
using PNWResource.API.Entities;

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
                var cityWithEvents = context.Cities
                    .Include(e => e.Events)
                    .Where(c => c.Id == cityId)
                    .FirstOrDefault();

                return cityWithEvents;
            }

            return await context.Cities.FindAsync(cityId);
        }

        public async Task<IEnumerable<Event?>> GetAllEventsAsync(int cityId)
        {
            return await context.Events.Where(p => p.CityId == cityId).ToListAsync();
        }

        public Task<Event?> GetEventAsync(int cityId, int playgroundId)
        {
            return context.Events
                .Where(p => p.CityId == cityId && p.Id == playgroundId).FirstOrDefaultAsync();
        }        
    }
}
