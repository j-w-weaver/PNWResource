using Microsoft.Extensions.Logging;

namespace PNWResource.API.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? State { get; set; } = string.Empty;

        public ICollection<Event>? Events { get; set; }
        public ICollection<School>? Schools { get; set; }
        public ICollection<Playground>? Playgrounds { get; set; }
        public ICollection<Park>? Parks { get; set; }
        public ICollection<Library>? Librarys { get; set; }
        public ICollection<Zoo>? Zoos { get; set; }
        public ICollection<DaycareCenter>? DaycareCenters { get; set; }

    }
}
