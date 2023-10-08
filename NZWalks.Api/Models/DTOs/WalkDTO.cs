using NZWalks.Api.Models.Entities;

namespace NZWalks.Api.Models.DTOs
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string WalkName { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //navigation properties - connection of entities
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }

    public class WalkRequestDTO
    {
        public Guid Id { get; set; }
        public string WalkName { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}
