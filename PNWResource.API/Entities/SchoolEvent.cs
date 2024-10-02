namespace PNWResource.API.Entities
{
    public class SchoolEvent
    {
        public int SchoolId { get; set; }
        public School School { get; set; } = new School();
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
    }
}
