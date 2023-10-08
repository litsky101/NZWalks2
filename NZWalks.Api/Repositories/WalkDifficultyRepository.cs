using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Entities;
using NZWalks.Api.Models.IRepositories;

namespace NZWalks.Api.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext context;

        public WalkDifficultyRepository(NZWalksDbContext _context)
        {
            context = _context;
        }
        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDiff)
        {
            walkDiff.Id = Guid.NewGuid();

            await context.AddAsync(walkDiff);

            await context.SaveChangesAsync();

            return walkDiff;
        }

        public async Task<WalkDifficulty?> DeleteAsync(Guid id)
        {
            var data = await context.WalkDifficulties.FirstOrDefaultAsync(w => w.Id == id);

            if(data == null)
            {
                return null;
            }
            else
            {
                context.WalkDifficulties.Remove(data);

                await context.SaveChangesAsync();

                return data;
            }
        }

        public async Task<IEnumerable<WalkDifficulty?>> GetAllAsync()
        {
            return await context.WalkDifficulties.ToListAsync();
        }

        public async Task<WalkDifficulty?> GetAsync(Guid id)
        {
            var data = await context.WalkDifficulties.FirstOrDefaultAsync(w => w.Id == id);

            return data;
        }

        public async Task<WalkDifficulty?> UpdateAsync(Guid id, WalkDifficulty walkDiff)
        {
            var data = await context.WalkDifficulties.FirstOrDefaultAsync(w => w.Id == id);

            if(data == null)
            {
                return null;
            }

            data.Code = walkDiff.Code;

            await context.SaveChangesAsync();

            return data;
        }
    }
}
