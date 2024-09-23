using PNWResource.API.Models;

namespace PNWResource.API.Controllers
{
    public static class Helpers
    {
        public static CityDTO? GetCity(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return null;
            }
            return city;
        }
    }
    
}
