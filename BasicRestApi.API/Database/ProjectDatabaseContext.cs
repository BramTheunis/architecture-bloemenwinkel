using BasicRestAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicRestAPI.Database
{
    public class ProjectDatabaseContext : DbContext
    {
        public ProjectDatabaseContext(DbContextOptions<ProjectDatabaseContext> ctx) : base(ctx)
        {
            
        }

        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<Flower> Flowers { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
    }
}