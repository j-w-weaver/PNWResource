namespace PNWResource.API.Entities
{
    public class LibraryEvent
    {
        public int LibraryId { get; set; }
        public Library Library { get; set; } = new Library();
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
    }
}
