using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.Api.Models.Entities
{
    public class Image
    {
        public Guid Id { get; set; }

        [NotMapped]
        public IFromFile File { get; set; }
        public string? FileName { get; set; }
        public string? FileExtension { get; set; }
        public long FileSizeInByes { get; set; }
        public string FilePath { get; set; }
    }
}
