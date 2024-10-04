namespace PNWResource.API.Entities
{
    public class Park
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public bool? HasPlayground { get; set; }
        public bool? HasPicnicArea { get; set; }

        public int? CityId { get; set; }
        public City? City { get; set; }

        public int? PlaygroundId { get; set; }
        public Playground? Playground { get; set; }

        //public ICollection<ParkEvent> ParkEvents { get; set; } = new List<ParkEvent>();
    }
}