namespace PNWResource.API.Entities
{
    public class DaycareCenter
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public SchoolType SchoolType { get; set; } = SchoolType.Daycare;

        // Foreign Key
        public int? CityId { get; set; }

        // Navigation property
        public City? City { get; set; }
    }
}