namespace PNWResource.API.Entities
{
    public class ParkEvent
    {
        public int ParkId { get; set; }
        public Park Park { get; set; } = new Park();
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
    }
}
