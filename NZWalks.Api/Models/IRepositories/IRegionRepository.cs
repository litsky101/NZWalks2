using NZWalks.Api.Models.Entities;

namespace NZWalks.Api.Models.IRepositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
