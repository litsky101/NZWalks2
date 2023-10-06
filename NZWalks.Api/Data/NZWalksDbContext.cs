using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Models.Entities;

namespace NZWalks.Api.Data
{
    public class NZWalksDbContext : DbContext
    {
        private readonly DbContextOptions<NZWalksDbContext> options;

        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> _options) : base(_options) 
        {
            options = _options;
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }
    }
}
