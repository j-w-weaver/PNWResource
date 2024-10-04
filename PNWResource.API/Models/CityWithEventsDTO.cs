using PNWResource.API.Entities;

namespace PNWResource.API.Models
{
    public class CityWithEventsDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? State { get; set; } = string.Empty;

        public ICollection<EventDTO>? Events { get; set; } = new List<EventDTO>();
    }
}
