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

        public async Task<IEnumerable<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 50)
        {
            //return await 
            //    context.Walks
            //    .Include(w => w.Region)
            //    .Include(w => w.WalkDifficulty)
            //    .ToListAsync();
            var walks = context.Walks.Include("Region").Include("WalkDifficulty").AsQueryable();

            //Filter
            if(!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(w => w.Name.Contains(filterQuery));
                }
                
            }

            //Sorting
            if(!string.IsNullOrEmpty(sortBy))
            {
                if(sortBy.Equals("Name" , StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ?  walks.OrderBy(w => w.Name) : walks.OrderByDescending(w => w.Name);
                }
                else if(sortBy.Equals ("Length" , StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(w => w.Length) : walks.OrderByDescending(w => w.Length);
                }
            }

            //Pagination
            var skipResult = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResult).Take(pageSize).ToListAsync();
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
