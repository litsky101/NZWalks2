using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.Api.Models.Entities
{
    public class Image
    {
        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public string? FileName { get; set; }
        public string? FileExtension { get; set; }
        public long FileSizeInByes { get; set; }
        public string FilePath { get; set; }
    }
}
