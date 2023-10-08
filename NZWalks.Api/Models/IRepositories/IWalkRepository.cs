using NZWalks.Api.Models.Entities;
using System.Globalization;

namespace NZWalks.Api.Models.IRepositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 50);

        Task<Walk?> GetAsync(Guid id);

        Task<Walk> AddAsync(Walk walk);

        Task<Walk?> DeleteAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id, Walk walk);
    }
}
