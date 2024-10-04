using AutoMapper;

namespace PNWResource.API.Profiles
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            CreateMap<Entities.Event, Models.EventDTO>();
        }
    }
}
