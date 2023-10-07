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

        public async Task<IEnumerable<Region?>> GetAllAsync()
        {
            return await context.Regions.ToListAsync();
        }

        public async Task<Region?> GetAsync(Guid id)
        {
            var region = await context.Regions.FirstOrDefaultAsync(r => r.Id == id);

            return region;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            
            await context.AddAsync(region);

            await context.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await context.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if(region == null)
            {
                return null;
            }
            else
            {
                context.Regions.Remove(region);

                await context.SaveChangesAsync();

                return region;
            }
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existRegionModel = await context.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if(existRegionModel == null)
            {
                return null;
            }
            else
            {
                existRegionModel.Code = region.Code;
                existRegionModel.Name = region.Name;
                existRegionModel.Area = region.Area;
                existRegionModel.Latitude = region.Latitude;
                existRegionModel.Longitude = region.Longitude;
                existRegionModel.Population = region.Population;

                await context.SaveChangesAsync();

                return existRegionModel;
            }
        }

    }
}
