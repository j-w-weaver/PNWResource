namespace PNWResource.API.Entities
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public bool? HasChildrenSection { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        //public ICollection<LibraryEvent> LibraryEvents { get; set; } = new List<LibraryEvent>();
    }
}