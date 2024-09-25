using System.ComponentModel.DataAnnotations;

namespace PNWResource.API.Models
{
    public class PlaygroundForCreationDTO
    {
        [Required(ErrorMessage = "Must provide a name.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
