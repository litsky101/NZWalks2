using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Models.DTOs
{
    public class ImageRequestDTO
    {
        [Required]
        public IFormFile File { get; set; }
        public string? FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
