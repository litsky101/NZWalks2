namespace NZWalks.Api.Models.Entities
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //navigation properties - connection of entities
        public Region Regions { get; set; }
        public WalkDifficulty WalkDifficulties { get; set; }
    }
}
