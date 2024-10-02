namespace PNWResource.API.Entities
{
    public class ZooEvent
    {
        public int ZooId { get; set; }
        public Zoo Zoo { get; set; } = new Zoo();
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
    }
}
