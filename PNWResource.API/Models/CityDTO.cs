namespace PNWResource.API.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<PlaygroundDTO>? Playground { get; set; } = new List<PlaygroundDTO>();
    }
}
