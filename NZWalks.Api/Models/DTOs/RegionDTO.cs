using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Models.DTOs
{
    public class RegionDTO
    {
        public Guid Id { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public double Area { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long Population { get; set; }
        public string RegionImageUrl { get; set; }
    }

    public class AddRegionDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has minimum of 3 characters.")]
        [MaxLength(3, ErrorMessage = "Code has maximum of 3 characters.")]
        public string RegionCode { get; set; }

        [Required]
        public string RegionName { get; set; }

        [Required]
        [Range(1, 100)]
        public double Area { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Population must be positive number or zero")]
        public long Population { get; set; }
        public string RegionImageUrl { get; set; }
    }

    public class UpdateRegionDTO
    {
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public double Area { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long Population { get; set; }
        public string RegionImageUrl { get; set; }
    }
}
