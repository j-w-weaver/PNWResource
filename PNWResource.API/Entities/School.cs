namespace PNWResource.API.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public SchoolType SchoolType { get; set; } = SchoolType.Unknown; 

        // Foreign Key
        public int? CityId { get; set; }

        // Navigation property
        public City? City { get; set; }
        //public ICollection<SchoolEvent> SchoolEvents { get; set; } = new List<SchoolEvent>();
    }

    public enum SchoolType
    {
        Unknown,
        Daycare,
        PreK,
        Kindergaren,
        Elementary,
        Middle,
        High
    }
}