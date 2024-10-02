using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNWResource.API.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? State { get; set; } = string.Empty;

        public ICollection<Event>? Events { get; set; } = new List<Event>();
        public ICollection<School>? Schools { get; set; } = new List<School>();
        public ICollection<Playground>? Playgrounds { get; set; } = new List<Playground>();
        public ICollection<Park>? Parks { get; set; } = new List<Park>();
        public ICollection<Library>? Librarys { get; set; } = new List<Library>();
        public ICollection<Zoo>? Zoos { get; set; } = new List<Zoo>();
        public ICollection<DaycareCenter>? DaycareCenters { get; set; } = new List<DaycareCenter>();
    }
}
