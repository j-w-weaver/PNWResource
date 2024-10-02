namespace PNWResource.API.Entities
{
    public class PlaygroundEvent
    {
        public int PlaygroundId { get; set; }
        public Playground Playground { get; set; } = new Playground();
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
    }
}
