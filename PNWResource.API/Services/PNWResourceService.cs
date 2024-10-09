using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PNWResource.API.Data;
using PNWResource.API.Entities;
using PNWResource.API.Models;
using System.Linq;

namespace PNWResource.API.Services
{
    public class PNWResourceService : IPNWResourceService
    {
        private readonly PNWResourceDbContext context;

        public PNWResourceService(PNWResourceDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await context.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<(IEnumerable<City>, PaginationMetadata)> GetCitiesAsync(string? name, string? searchQuery,
            int pageNumber, int pageSize)
        {           
            var collection = context.Cities as IQueryable<City>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(c => c.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);
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

        public async Task<bool> CityExistsAsync(int cityId)
        {
            return await context.Cities.AnyAsync(c => c.Id == cityId);
        }

        public async Task AddEventForCityAsync(int cityId, Event eventToAdd)
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

        public void DeleteCityEventAsync(Event eventToDelete)
        {
            context.Remove(eventToDelete);
        }
    }
}
