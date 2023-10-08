using NZWalks.Api.Models.Entities;

namespace NZWalks.Api.Models.IRepositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty?>> GetAllAsync();

        Task<WalkDifficulty?> GetAsync(Guid id);

        Task<WalkDifficulty> AddAsync(WalkDifficulty walkDiff);

        Task<WalkDifficulty?> DeleteAsync(Guid id);

        Task<WalkDifficulty?> UpdateAsync(Guid id, WalkDifficulty walkDiff);
    }
}
