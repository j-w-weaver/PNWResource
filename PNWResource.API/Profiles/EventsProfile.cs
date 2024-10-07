using AutoMapper;

namespace PNWResource.API.Profiles
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            CreateMap<Entities.Event, Models.EventDTO>();
            CreateMap<Models.EventToAddDTO, Entities.Event>();
            CreateMap<Models.EventToUpdateDTO, Entities.Event>();
            CreateMap<Entities.Event, Models.EventToUpdateDTO>();
        }
    }
}
