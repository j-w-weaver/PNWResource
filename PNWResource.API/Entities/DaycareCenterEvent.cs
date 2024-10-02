namespace PNWResource.API.Entities
{
    public class DaycareCenterEvent
    {
        public int DaycareCenterId { get; set; }
        public DaycareCenter DaycareCenter { get; set; } = new DaycareCenter();
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
    }
}
