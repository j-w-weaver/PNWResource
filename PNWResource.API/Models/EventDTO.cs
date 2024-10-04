namespace PNWResource.API.Models
{
    public class EventDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? TimeStarts { get; set; } = string.Empty;
        public string? TimeEnds { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
