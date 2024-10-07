using AutoMapper;

namespace PNWResource.API.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<Entities.City, Models.CityDTO>();
            CreateMap<Entities.City, Models.CityWithEventsDTO>();
        }
    }
}
