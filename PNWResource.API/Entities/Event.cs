namespace PNWResource.API.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? TimeStarts { get; set; } = string.Empty;
        public string? TimeEnds { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Foreign Key
        public int? CityId { get; set; }

        // Navigation property
        public City? City { get; set; }
    }
}