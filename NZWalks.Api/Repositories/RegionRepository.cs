using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Entities;
using NZWalks.Api.Models.IRepositories;

namespace NZWalks.Api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext context;

        public RegionRepository(NZWalksDbContext _context)
        {
            context = _context;
        }

        async Task<IEnumerable<Region>> IRegionRepository.GetAllAsync()
        {
            return await context.Regions.ToListAsync();
        }
    }
}
