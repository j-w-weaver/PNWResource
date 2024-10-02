using System.ComponentModel.DataAnnotations.Schema;

namespace PNWResource.API.Entities
{
    public class Playground
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? State { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public bool? HasBathrooms { get; set; }
        public bool? IsPetFriendly { get; set; }

        public DateTime? DateConstructed { get; set; }
        public DateTime? DateUpdated { get; set; }

        public int? ParkId { get; set; }
        public Park? Park { get; set; }

        // Foreign Key
        public int? CityId { get; set; }

        // Navigation property
        public City? City { get; set; }
        public ICollection<PlaygroundEvent> PlaygroundEvents { get; set; } = new List<PlaygroundEvent>();
    }
}