using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Entities;
using NZWalks.Api.Models.IRepositories;

namespace NZWalks.Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext context;

        public WalkRepository(NZWalksDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await 
                context.Walks
                .Include(w => w.Region)
                .Include(w => w.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();

            await context.AddAsync(walk);

            await context.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walk = await context.Walks.FirstOrDefaultAsync(r => r.Id == id);

            if(walk == null)
            {
                return null;
            }
            else
            {
                context.Walks.Remove(walk);

                await context.SaveChangesAsync();

                return walk;
            }
        }

        public async Task<Walk?> GetAsync(Guid id)
        {
            return await context.Walks.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await context.Walks.FirstOrDefaultAsync(w => w.Id == id);

            if(existingWalk == null)
            {
                return null;
            }
            else
            {
                existingWalk.Name = walk.Name;
                existingWalk.Length = walk.Length;
                existingWalk.RegionId = walk.RegionId;
                existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
                existingWalk.ImageUrl = walk.ImageUrl;

                await context.SaveChangesAsync();

                return existingWalk;
            }
        }
    }
}
