namespace NZWalks.Api.Models.DTOs
{
    public class WalkDifficultyResponseDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }

    public class WalkDifficultyRequestDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }
}
