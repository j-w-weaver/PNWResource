namespace PNWResource.API.Entities
{
    public class Zoo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public bool? HasChildrenArea { get; set; }

        public int? CityId { get; set; }
        public City? City { get; set; }
        //public ICollection<ZooEvent> ZooEvents { get; set; } = new List<ZooEvent>();
    }
}